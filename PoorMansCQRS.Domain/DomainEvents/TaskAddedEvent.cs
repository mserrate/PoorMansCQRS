using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Domain.DomainEvents
{
    public class TaskAddedEvent : IEvent
    {
        public readonly Guid ProjectId;
        public readonly Guid TaskId;
        public readonly string Name;
        public readonly string Description;

        public TaskAddedEvent(
            Guid projectId,
            Guid taskId,
            string name,
            string description)
        {
            ProjectId = projectId;
            TaskId = taskId;
            Name = name;
            Description = description;
        }
    }
}
