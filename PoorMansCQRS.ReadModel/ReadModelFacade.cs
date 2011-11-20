using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using PoorMansCQRS.Domain;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace PoorMansCQRS.ReadModel
{
    public class ReadModelFacade : IReadModelFacade
    {
        private readonly ISessionFactory _sessionFactory;

        public ReadModelFacade(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IList<ProjectItem> GetProjectList()
        {      
            ProjectItem item = null;
            var brList = _sessionFactory.GetCurrentSession().QueryOver<Project>()
                .Where(Expression.Not(Expression.Eq("_status", 3)))
                .SelectList(list => list
                    .Select(Projections.Property("_id")).WithAlias(() => item.Id)
                    .Select(Projections.Property("_code")).WithAlias(() => item.Code)                    
                    .Select(Projections.Property("_name")).WithAlias(() => item.Name)
                    .Select(Projections.Cast(
                                NHibernateUtil.Enum(typeof(ProjectStatus)), 
                                Projections.Property("_status")).WithAlias(() => item.Status)
                            )
                    )
                .TransformUsing(Transformers.AliasToBean<ProjectItem>())
                .List<ProjectItem>();

            return brList;
        }

        public ProjectDetails GetProjectDetails(Guid id)
        {
            ProjectDetails projectDetails = null;           

            projectDetails = _sessionFactory.GetCurrentSession().QueryOver<Project>()
                .Where(Expression.Eq("_id", id))
                .Select(
                    Projections.Property("_id").WithAlias(() => projectDetails.Id),
                    Projections.Property("_code").WithAlias(() => projectDetails.Code),
                    Projections.Property("_name").WithAlias(() => projectDetails.Name),
                    Projections.Property("_deliveryDate").WithAlias(() => projectDetails.DeliveryDate),
                    Projections.Cast(
                                NHibernateUtil.Enum(typeof(ProjectStatus)),
                                Projections.Property("_status")).WithAlias(() => projectDetails.Status)
                    )
                .TransformUsing(Transformers.AliasToBean<ProjectDetails>())
                .SingleOrDefault<ProjectDetails>();           

            return projectDetails;
        }

        public IList<TaskItem> GetTaskListByProject(Guid id)
        {
            TaskItem taskItem = null;

            return _sessionFactory.GetCurrentSession().QueryOver<Task>()
                .Where(Expression.Eq("_aggregateRoot._id", id))
                .And(Expression.Not(Expression.Eq("_status", 3)))
                .SelectList(list => list
                    .Select(Projections.Property("_id")).WithAlias(() => taskItem.Id)
                    .Select(Projections.Property("_name")).WithAlias(() => taskItem.Name)
                    .Select(Projections.Cast(
                                NHibernateUtil.Enum(typeof(TaskStatus)),
                                Projections.Property("_status")).WithAlias(() => taskItem.Status)
                            )
                    )
                .TransformUsing(Transformers.AliasToBean<TaskItem>())
                .List<TaskItem>();
        }


        public DateTime GetProjectDeliveryDate(Guid id)
        {
            return _sessionFactory.GetCurrentSession().QueryOver<Project>()
                .Where(Expression.Eq("_id", id))
                .Select(Projections.Property("_deliveryDate"))
                .SingleOrDefault<DateTime>();
        }

        public TaskDetails GetTaskDetails(Guid id)
        {
            TaskDetails taskDetails = null;

            taskDetails = _sessionFactory.GetCurrentSession().QueryOver<Task>()
                .Where(Expression.Eq("_id", id))
                .Select(
                    Projections.Property("_id").WithAlias(() => taskDetails.Id),
                    Projections.Property("_aggregateRoot._id").WithAlias(() => taskDetails.ProjectId),
                    Projections.Property("_name").WithAlias(() => taskDetails.Name),
                    Projections.Property("_description").WithAlias(() => taskDetails.Description),
                    Projections.Cast(
                                NHibernateUtil.Enum(typeof(TaskStatus)),
                                Projections.Property("_status")).WithAlias(() => taskDetails.Status)
                    )
                .TransformUsing(Transformers.AliasToBean<TaskDetails>())
                .SingleOrDefault<TaskDetails>();

            return taskDetails;
        }
    }
}
