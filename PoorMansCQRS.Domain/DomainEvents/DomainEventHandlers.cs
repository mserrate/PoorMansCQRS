using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Domain.DomainEvents
{
    public class DomainEventHandlers : 
        IEventHandler<ProjectAddedEvent>,
        IEventHandler<ProjectClosedEvent>,
        IEventHandler<ProjectDeactivatedEvent>,
        IEventHandler<DeliveryDateChangedEvent>,
        IEventHandler<TaskAddedEvent>,
        IEventHandler<TaskClosedEvent>,
        IEventHandler<TaskDeactivatedEvent>
    {
        public void Handle(ProjectAddedEvent args)
        {
            //NOOP
        }

        public void Handle(DeliveryDateChangedEvent args)
        {
            //NOOP
        }

        public void Handle(TaskAddedEvent args)
        {
            //NOOP
        }

        public void Handle(TaskClosedEvent args)
        {
            //NOOP
        }

        public void Handle(ProjectClosedEvent args)
        {
            //NOOP
        }

        public void Handle(ProjectDeactivatedEvent args)
        {
            //NOOP
        }

        public void Handle(TaskDeactivatedEvent args)
        {
            //NOOP
        }
    }
}
