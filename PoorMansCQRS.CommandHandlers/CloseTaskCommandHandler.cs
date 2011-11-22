using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Commands;
using PoorMansCQRS.Domain;

namespace PoorMansCQRS.CommandHandlers
{
    public class CloseTaskCommandHandler : ICommandHandler<CloseTaskCommand>
    {
        private readonly IRepository<Project> _repository;

        public CloseTaskCommandHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public void Handle(CloseTaskCommand command)
        {
            var aggregate = _repository.GetById(command.ProjectId);
            aggregate.CloseTask(command.TaskId);
            _repository.Save(aggregate);
        }
    }
}
