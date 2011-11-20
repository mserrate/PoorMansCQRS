using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Commands;

namespace PoorMansCQRS.CommandHandlers
{
    public interface ICommandHandler<T> 
        where T : ICommand
    {
        void Handle(T command);
    }
}
