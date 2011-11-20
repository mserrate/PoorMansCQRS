using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoorMansCQRS.Domain.DomainEvents;

namespace PoorMansCQRS.Domain
{
    public abstract class AggregateRoot : IEntity
    {
        public abstract Guid Id { get; }

        internal void ApplyEvent<T>(T args) 
            where T : IEvent
        {
            DomainEvents.DomainEvents.Raise(args);
        }
    }

    public interface IEntity
    {
        Guid Id { get; }
    }
}
