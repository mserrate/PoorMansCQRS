using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Commands;
using PoorMansCQRS.Domain;

namespace PoorMansCQRS.CommandHandlers
{
    public class CloseProjectCommandHandler : ICommandHandler<CloseProjectCommand>
    {
        private readonly IRepository<Project> _repository;

        public CloseProjectCommandHandler(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public void Handle(CloseProjectCommand command)
        {
            var aggregate = _repository.GetById(command.Id);
            aggregate.Close();
            _repository.Save(aggregate);
        }
    }
}
