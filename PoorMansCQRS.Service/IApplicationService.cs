using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Commands;

namespace PoorMansCQRS.Service
{
    public interface IApplicationService
    {
        void Execute<T>(T command) where T : ICommand;
    }
}
