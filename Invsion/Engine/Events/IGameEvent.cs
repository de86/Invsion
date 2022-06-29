using System;

namespace Invsion.Engine.Events
{
    public interface IGameEvent<T>
    {
        public void Invoke (object eventSource, T eventName);

        public void Subscribe (EventHandler<T> handler);

        public void Unsubscribe (EventHandler<T> handler);

        public void UnsubscribeAll (EventHandler<T> handler);
    }
}
