using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using PoorMansCQRS.Data;
using PoorMansCQRS.Domain;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using PoorMansCQRS.ReadModel;

namespace PoorMansCQRS.Infrastructure.Installers
{
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IRepository<>))
                .ImplementedBy(typeof(Repository<>)));

            container.Register(Component.For<ISessionFactory>()
                .UsingFactoryMethod(x => CreateSessionFactory()));

            container.Register(Component.For<NHibernateSessionModule>());

            container.Register(Component.For<IReadModelFacade>()
                .ImplementedBy<ReadModelFacade>());
        }

        private ISessionFactory CreateSessionFactory()
        {
            return
                Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("PoorMansCS")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProjectMap>()
                    .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()))
                .CurrentSessionContext("web")
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private void BuildSchema(Configuration config)
        {
            var buildSchema = System.Configuration.ConfigurationManager.AppSettings["BuildSchema"];
            bool build = false;
            bool.TryParse(buildSchema, out build);

            if (build)
            {
                new SchemaExport(config)
                  .Create(false, true);
            }
        }
    }
}
