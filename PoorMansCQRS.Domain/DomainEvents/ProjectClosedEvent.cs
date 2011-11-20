using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Domain.DomainEvents
{
    public class ProjectClosedEvent : IEvent
    {
        public readonly Guid ProjectId;

        public ProjectClosedEvent(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
