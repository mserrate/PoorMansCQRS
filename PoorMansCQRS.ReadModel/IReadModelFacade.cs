using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.ReadModel
{
    public interface IReadModelFacade
    {
        IList<ProjectItem> GetProjectList();
        ProjectDetails GetProjectDetails(Guid id);
        IList<TaskItem> GetTaskListByProject(Guid id); 
        DateTime GetProjectDeliveryDate(Guid id);
        TaskDetails GetTaskDetails(Guid id);
    }
}
