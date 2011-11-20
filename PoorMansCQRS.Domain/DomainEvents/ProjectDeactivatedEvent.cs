using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Domain.DomainEvents
{
    public class ProjectDeactivatedEvent : IEvent
    {
        public readonly Guid ProjectId;

        public ProjectDeactivatedEvent(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
