using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using System.Web.Mvc;
using System.Reflection;

namespace PoorMansCQRS.Infrastructure.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromAssemblyNamed("PoorMansCQRS.Web")
                .BasedOn<IController>()
                .If(Component.IsInNamespace("PoorMansCQRS.Web.Controllers"))
                .If(t => t.Name.EndsWith("Controller"))
                .Configure(c => c.LifeStyle.Transient));
        }
    }
}
