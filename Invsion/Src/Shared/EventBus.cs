using System;
using System.Collections.Generic;
using System.Text;

namespace Invsion.Engine
{
    public class EventBus
    {
        public GameEvent<string> InputPressed = new GameEvent<string>();
        /*private static event EventHandler<string> _onInputPressed;
        public static void InvokeInputPressedEvent(object eventSource, string eventName)
        {
            _onInputPressed?.Invoke(eventSource, eventName);
        }

        public static void SubscribeToInputPressedEvent (EventHandler<string> handler)
        {
            _onInputPressed += handler;
        }*/




        /*private event EventHandler<EventArgs> _onSkipScreen;
        public void InvokeSkipScreenEvent (object eventSource)
        {
            _onSkipScreen?.Invoke(eventSource, EventArgs.Empty);
        }

        public void SubscribeToSkipScreenEvent (EventHandler<EventArgs handler)
        {
            _onSkipScreen += handler;
        }*/
    }
}
