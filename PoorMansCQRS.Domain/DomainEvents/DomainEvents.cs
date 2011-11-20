using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.ServiceLocation;

namespace PoorMansCQRS.Domain.DomainEvents
{
    /// <summary>
    /// Domain Events
    /// http://www.udidahan.com/2009/06/14/domain-events-salvation/
    /// </summary>
    public static class DomainEvents
    {
        [ThreadStatic]
        private static List<Delegate> _actions;

        public static void Register<T>(Action<T> callback)
            where T : IEvent
        {
            if (_actions == null)
                _actions = new List<Delegate>();

            _actions.Add(callback);
        }

        public static void ClearCallbacks()
        {
            _actions = null;
        }

        public static void Raise<T>(T args)
            where T : IEvent
        {
            var registeredHandlers = ServiceLocator.Current.GetAllInstances<IEventHandler<T>>();

            foreach (var handler in registeredHandlers)
            {
                handler.Handle(args);
            }

            if (_actions == null)
                return;

            foreach (var action in _actions)
            {
                if (action is Action<T>)
                    ((Action<T>)action)(args);
            }
        }
    }
}
