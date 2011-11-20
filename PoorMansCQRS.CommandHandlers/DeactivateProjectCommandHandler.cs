using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Commands;
using PoorMansCQRS.Domain;

namespace PoorMansCQRS.CommandHandlers
{
    public class DeactivateProjectCommandHandler: ICommandHandler<DeactivateProjectCommand>
    {
        private readonly IRepository<Project> _repository;

        public DeactivateProjectCommandHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public void Handle(DeactivateProjectCommand command)
        {
            var aggregate = _repository.GetById(command.Id);
            aggregate.Deactivate();
            _repository.Save(aggregate);
        }
    }
}
