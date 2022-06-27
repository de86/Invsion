using System;
using System.Collections.Generic;
using System.Text;

namespace Invsion.Engine
{
    public class GameEvent<T>
    {
        private event EventHandler<T> _eventHandlers;
        public void Invoke (object eventSource, T eventName)
        {
            _eventHandlers?.Invoke(eventSource, eventName);
        }

        public void Subscribe (EventHandler<T> handler)
        {
            _eventHandlers += handler;
        }

        public void Unsubscribe (EventHandler<T> handler)
        {
            _eventHandlers -= handler;
        }

        public void UnsubscribeAll (EventHandler<T> handler)
        {
            _eventHandlers = null;
        }
    }
}
