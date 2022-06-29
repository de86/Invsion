
using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;

using Invsion.Engine.Input;

using Invsion.Src.Constants;

namespace Invsion.Engine.Events
{
    public class InputEventBus
    {
        // object is ok for now but would be nice to find a way to properly handle
        // generic event args without typing the dictionary itself
        private Dictionary<string, GameEvent<object>> _actionEventBindings;

        public GameEvent<object> InputPressed = new GameEvent<object>();


        public InputEventBus ()
        {
            _actionEventBindings = new Dictionary<string, GameEvent<object>>();
            _actionEventBindings.Add(INPUT_ACTIONS.FIRE_PRIMARY, InputPressed);
        }



        public void InvokeInputEvent (IInputManager sourceInputManager, string action)
        {
            GameEvent<object> eventHandler;
            _actionEventBindings.TryGetValue(action, out eventHandler);

            if (eventHandler == null)
                return;

            eventHandler?.Invoke(sourceInputManager, action);
        }



        public void AddInputEvent (string input, GameEvent<object> eventHandlers)
        {
            _actionEventBindings.Add(input, eventHandlers);
        }



        public void SubscribeToEvent (string inputAction, EventHandler<object> handler)
        {
            GameEvent<object> eventHandler;
            _actionEventBindings.TryGetValue(inputAction, out eventHandler);

            if (eventHandler == null)
                return;

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
