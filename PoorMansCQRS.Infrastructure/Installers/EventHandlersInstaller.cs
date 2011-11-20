using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using PoorMansCQRS.Domain.DomainEvents;

namespace PoorMansCQRS.Infrastructure.Installers
{
    public class EventHandlersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromAssemblyContaining<DomainEventHandlers>()
                .BasedOn(typeof(IEventHandler<>))
                .WithService.Base());
        }
    }
}
