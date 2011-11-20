using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Commands;
using PoorMansCQRS.Domain;

namespace PoorMansCQRS.CommandHandlers
{
    public class DeactivateTaskCommandHandler : ICommandHandler<DeactivateTaskCommand>
    {
        private readonly IRepository<Project> _repository;

        public DeactivateTaskCommandHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public void Handle(DeactivateTaskCommand command)
        {
            var aggregate = _repository.GetById(command.ProjectId);
            aggregate.DeactivateTask(command.TaskId);
            _repository.Save(aggregate);
        }
    }
}
