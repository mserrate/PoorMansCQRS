using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Commands;
using PoorMansCQRS.CommandHandlers;
using Microsoft.Practices.ServiceLocation;

namespace PoorMansCQRS.Service
{
    public class ApplicationService : IApplicationService
    {
        public void Execute<T>(T command)
            where T : ICommand
        {
            var handler = ServiceLocator.Current.GetInstance<ICommandHandler<T>>();
            handler.Handle(command);
        }
    }
}
