using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DynamicTabLib.Framework
{
    public class EventAggregator : IEventAggregator
    {
        private readonly Dictionary<Type, EventBase> _events = new Dictionary<Type, EventBase>();

        private readonly SynchronizationContext _syncContext = SynchronizationContext.Current;

        public T GetEvent<T>() where T : EventBase, new()
        {
            lock (_events)
            {
                EventBase existingEvent = null;

                if (!_events.TryGetValue(typeof(T), out existingEvent))
                {
                    T newEvent = new T();
                    newEvent.SynchronizationContext = _syncContext;
                    _events[typeof(T)] = newEvent;

                    return newEvent;
                }
                else
                {
                    return existingEvent as T;
                }
            }
        }
    }
}
