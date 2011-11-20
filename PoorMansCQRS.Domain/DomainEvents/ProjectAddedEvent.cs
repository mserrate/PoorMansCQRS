using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Domain.DomainEvents
{
    public class ProjectAddedEvent : IEvent
    {
        public readonly Guid ProjectId;
        public readonly string Code;
        public readonly string Name;
        public readonly DateTime DeliveryDate;

        public ProjectAddedEvent(Guid projectId, string code, string name, DateTime deliveryDate)
        {
            ProjectId = projectId;
            Code = code;
            Name = name;
            DeliveryDate = deliveryDate;
        }
    }
}
