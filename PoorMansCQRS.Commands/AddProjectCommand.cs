using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Commands
{
    public class AddProjectCommand : ICommand
    {
        public readonly string Code;
        public readonly string Name;
        public readonly DateTime DeliveryDate;

        public AddProjectCommand(string code, string name, DateTime deliveryDate)
        {
            Code = code;
            Name = name;
            DeliveryDate = deliveryDate;
        }
    }
}
