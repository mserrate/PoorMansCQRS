using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.Domain
{
    public interface IRepository<T>
        where T : AggregateRoot
    {
        T GetById(Guid id);
        void Save(T aggregate);
    }
}
