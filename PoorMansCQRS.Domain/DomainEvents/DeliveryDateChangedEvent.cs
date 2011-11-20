using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Domain.DomainEvents
{
    public class DeliveryDateChangedEvent : IEvent
    {
        public readonly Guid ProjectId;
        public readonly DateTime DeliveryDate;

        public DeliveryDateChangedEvent(Guid projectId, DateTime deliveryDate)
        {
            ProjectId = projectId;
            DeliveryDate = deliveryDate;
        }
    }
}
