using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Commands
{
    public class CloseTaskCommand : ICommand
    {
        public readonly Guid ProjectId;
        public readonly Guid TaskId;

        public CloseTaskCommand(Guid projectId, Guid taskId)
        {
            ProjectId = projectId;
            TaskId = taskId;
        }
    }
}
