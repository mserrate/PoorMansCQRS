using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Commands
{
    public class AddTaskCommand : ICommand
    {
        public readonly string Name;
        public readonly string Description;
        public readonly Guid ProjectId;

        public AddTaskCommand(string name,
            string description,
            Guid projectId)
        {
            Name = name;
            Description = description;
            ProjectId = projectId;
        }
    }
}
