using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Domain.DomainEvents
{
    public class TaskDeactivatedEvent : IEvent
    {
        public readonly Guid ProjectId;
        public readonly Guid TaskId;

        public TaskDeactivatedEvent(
            Guid projectId,
            Guid taskId)
        {
            ProjectId = projectId;
            taskId = TaskId;
        }
    }
}
