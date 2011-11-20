using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Domain.DomainEvents;
using PoorMansCQRS.Domain.Exceptions;

namespace PoorMansCQRS.Domain
{
    public class Project : AggregateRoot
    {
        #region Project Status
        public enum ProjectStatus : int
        {
            Active = 1,
            Closed = 2,
            Inactive = 3
        }
        #endregion

        private Guid _id;
        private string _code;
        private string _name;
        private DateTime _deliveryDate;
        private ProjectStatus _status;
        private IList<Task> _tasks;

        private Project()
        { }

        public Project(string code, string name, DateTime deliveryDate)
        {
            _id = Guid.NewGuid();
            _code = code;
            _name = name;
            _status = ProjectStatus.Active;
            IsValidDeliveryDate(deliveryDate);
            _deliveryDate = deliveryDate;
            _tasks = new List<Task>();

            ApplyEvent(new ProjectAddedEvent(_id, _code, _name, _deliveryDate));
        }

        public void ChangeDeliveryDate(DateTime deliveryDate)
        {
            IsProjectClosed();
            IsValidDeliveryDate(deliveryDate);

            _deliveryDate = deliveryDate;

            ApplyEvent(new DeliveryDateChangedEvent(_id, _deliveryDate));
        }

        public void Close()
        {           
            if (_status != ProjectStatus.Closed)
            {
                _status = ProjectStatus.Closed;
                ApplyEvent(new ProjectClosedEvent(_id));
            }
        }

        public void Deactivate()
        {
            IsProjectClosed();

            if (_status != ProjectStatus.Inactive)
            {
                _status = ProjectStatus.Inactive;
                ApplyEvent(new ProjectDeactivatedEvent(_id));
            }
        }

        public void AddTask(string name, string description)
        {
            IsProjectClosed();

            var task = new Task(this, name, description);
            _tasks.Add(task);
        }

        public void CloseTask(Guid taskId)
        {
            IsProjectClosed();

            var task = _tasks.SingleOrDefault(t => t.Id == taskId);

            if (task == null)
                throw new NonExistingTaskException("Task does not exist");

            task.Close();
        }

        public void DeactivateTask(Guid taskId)
        {
            IsProjectClosed();

            var task = _tasks.SingleOrDefault(t => t.Id == taskId);

            if (task == null)
                throw new NonExistingTaskException("Task does not exist");

            task.Deactivate();
        }

        private void IsProjectClosed()
        {
            if (_status == ProjectStatus.Closed)
                throw new ProjectIsClosedException("The action could not be processed because the project is closed");
        }

        private void IsValidDeliveryDate(DateTime deliveryDate)
        {
            if (deliveryDate < DateTime.Now)
                throw new InvalidDeliveryDateException("Delivery date is not a valid date");
        }

        public override Guid Id
        {
            get { return _id; }
        }
    }
}
