using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using PoorMansCQRS.CommandHandlers;

namespace PoorMansCQRS.Infrastructure.Installers
{
    public class CommandsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IApplicationService>()
                .ImplementedBy<ApplicationService>(),

                AllTypes.FromAssemblyContaining<AddProjectCommandHandler>()
                .BasedOn(typeof(ICommandHandler<>))
                .WithService.Base()
            );
        }
    }
}
