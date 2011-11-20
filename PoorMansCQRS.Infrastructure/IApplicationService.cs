using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Commands;

namespace PoorMansCQRS.Infrastructure
{
    public interface IApplicationService
    {
        void Send<T>(T command) where T : ICommand;
    }
}
