using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Commands
{
    public class CloseProjectCommand : ICommand
    {
        public readonly Guid Id;

        public CloseProjectCommand(Guid id)
        {
            Id = id;
        }
    }
}
