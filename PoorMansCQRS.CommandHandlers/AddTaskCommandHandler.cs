using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Commands;
using PoorMansCQRS.Domain;

namespace PoorMansCQRS.CommandHandlers
{
    public class AddTaskCommandHandler : ICommandHandler<AddTaskCommand>
    {
        private readonly IRepository<Project> _repository;

        public AddTaskCommandHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public void Handle(AddTaskCommand command)
        {
            var aggregate = _repository.GetById(command.ProjectId);
            aggregate.AddTask(command.Name, command.Description);
            _repository.Save(aggregate);
        }
    }
}
