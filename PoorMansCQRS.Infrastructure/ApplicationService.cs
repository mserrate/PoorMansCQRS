using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Commands;
using PoorMansCQRS.CommandHandlers;

namespace PoorMansCQRS.Infrastructure
{
    public class ApplicationService : IApplicationService
    {
        public void Send<T>(T command)
            where T : ICommand
        {
            var handler = WindsorApplication.container.GetService<ICommandHandler<T>>();
            handler.Handle(command);
        }
    }
}
