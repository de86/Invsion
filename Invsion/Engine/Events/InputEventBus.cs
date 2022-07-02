
using System;
using System.Diagnostics;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;

using Invsion.Engine.Input;

using Invsion.Src.Constants;

namespace Invsion.Engine.Events
{
    public class InputEventBus : IInputEventBus
    {
        // object is ok for now but would be nice to find a way to properly handle
        // generic event args without typing the dictionary itself
        private Dictionary<string, GameEvent<object>> _actionEventBindings;


        public InputEventBus ()
        {
            _actionEventBindings = new Dictionary<string, GameEvent<object>>();
            
        }



        public void CreateEventForAction (string action)
        {
            _actionEventBindings.Add(action, new GameEvent<object>());
        }



        public void InvokeInputEvent (IInputManager sourceInputManager, string action, ushort state)
        {
            GameEvent<object> eventHandler;
            _actionEventBindings.TryGetValue(action, out eventHandler);

            if (eventHandler == null)
            {
                Debug.WriteLine($"No event handler found for action {action}");
                return;
            }

            eventHandler?.Invoke(sourceInputManager, state);
        }



        public void SubscribeToEvent (string inputAction, EventHandler<object> handler)
        {
            GameEvent<object> eventHandler;
            _actionEventBindings.TryGetValue(inputAction, out eventHandler);

            if (eventHandler == null)
                throw new IndexOutOfRangeException(inputAction);

            eventHandler?.Subscribe(handler);
        }



        public void UnsubscribeFromEvent (string inputAction, EventHandler<object> eventHandler)
        {
            GameEvent<object> eventHandlers;
            _actionEventBindings.TryGetValue(inputAction, out eventHandlers);

            if (eventHandler == null)
                return;

            eventHandlers?.Unsubscribe(eventHandler);
        }
    }
}
