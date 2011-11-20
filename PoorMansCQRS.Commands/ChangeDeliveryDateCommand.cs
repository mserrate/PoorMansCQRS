using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Commands
{
    public class ChangeDeliveryDateCommand : ICommand
    {
        public readonly Guid ProjectId;
        public readonly DateTime DeliveryDate;

        public ChangeDeliveryDateCommand(
            Guid projectId,
            DateTime deliveryDate)
        {
            ProjectId = projectId;
            DeliveryDate = deliveryDate;
        }
    }
}
