using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Commands
{
    public class DeactivateProjectCommand : ICommand
    {
        public readonly Guid Id;

        public DeactivateProjectCommand(Guid id)
        {
            Id = id;
        }
    }
}
