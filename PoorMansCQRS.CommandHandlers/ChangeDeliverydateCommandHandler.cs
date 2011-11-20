using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Commands;
using PoorMansCQRS.Domain;

namespace PoorMansCQRS.CommandHandlers
{
    public class ChangeDeliverydateCommandHandler : ICommandHandler<ChangeDeliveryDateCommand>
    {
        private readonly IRepository<Project> _repository;

        public ChangeDeliverydateCommandHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public void Handle(ChangeDeliveryDateCommand command)
        {
            var aggregate = _repository.GetById(command.ProjectId);
            aggregate.ChangeDeliveryDate(command.DeliveryDate);
            _repository.Save(aggregate);
        }
    }
}
