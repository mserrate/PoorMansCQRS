using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Castle.Windsor;
using PoorMansCQRS.Infrastructure.Installers;
using System.Web.Mvc;
using Castle.Windsor.Installer;
using Microsoft.Practices.ServiceLocation;
using CommonServiceLocator.WindsorAdapter;

namespace PoorMansCQRS.Infrastructure
{
    public class WindsorApplication : HttpApplication, IContainerAccessor
    {
        internal static IWindsorContainer container;

        public IWindsorContainer Container
        {
            get { return container; }
        }

        protected virtual void Application_Start()
        {
            BootstrapContainer();
        }

        protected void Application_End()
        {
            container.Dispose();
        }

        private static void BootstrapContainer()
        {
            container = new WindsorContainer()
                .Install(FromAssembly.This());

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        public override void Init()
        {
            base.Init();
            InitModules();
        }

        private void InitModules()
        {
            var modules = container.ResolveAll<IHttpModule>();

            foreach (var item in modules)
            {
                item.Init(this);
            }
        }
    }
}
