using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Commands;
using PoorMansCQRS.Domain;

namespace PoorMansCQRS.CommandHandlers
{
    public class AddProjectCommandHandler : ICommandHandler<AddProjectCommand>
    {
        private readonly IRepository<Project> _repository;

        public AddProjectCommandHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public void Handle(AddProjectCommand command)
        {
            var aggregate = new Project(command.Code, command.Name, command.DeliveryDate);
            _repository.Save(aggregate);
        }
    }
}
