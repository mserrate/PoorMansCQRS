using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Domain.DomainEvents;
using PoorMansCQRS.Domain.Exceptions;

namespace PoorMansCQRS.Domain
{
    public class Task : IEntity
    {
        #region Task Status
        public enum TaskStatus : int
        {
            Active = 1,
            Closed = 2,
            Inactive = 3
        }
        #endregion

        private AggregateRoot _aggregateRoot;
        private Guid _id;
        private string _name;
        private string _description;
        private TaskStatus _status;

        private Task()
        { }

        public Task(AggregateRoot aggregateRoot, string name, string description)
        {
            _id = Guid.NewGuid();
            _aggregateRoot = aggregateRoot;
            _name = name;
            _description = description;
            _status = TaskStatus.Active;

            _aggregateRoot.ApplyEvent(new TaskAddedEvent(_aggregateRoot.Id, _id, _name, _description));
        }

        public void Close()
        {
            if (_status != TaskStatus.Closed)
            {
                _status = TaskStatus.Closed;
                _aggregateRoot.ApplyEvent(new TaskClosedEvent(_aggregateRoot.Id, _id));
            }
        }

        public void Deactivate()
        {
            if (_status == TaskStatus.Closed)
                throw new TaskIsClosedException("a closed task could not be deactivated");

            if (_status != TaskStatus.Inactive)
            {
                _status = TaskStatus.Inactive;
                _aggregateRoot.ApplyEvent(new TaskDeactivatedEvent(_aggregateRoot.Id, _id));
            }
        }

        public Guid Id
        {
            get { return _id; }
        }
    }
}
