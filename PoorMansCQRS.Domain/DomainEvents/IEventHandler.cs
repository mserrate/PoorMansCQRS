using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Domain.DomainEvents
{
    public interface IEventHandler<T> 
        where T : IEvent
    {
        void Handle(T args);
    }
}
