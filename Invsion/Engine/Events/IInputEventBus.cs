using System;
using System.Collections.Generic;
using System.Text;

using Invsion.Engine.Input;

namespace Invsion.Engine.Events
{
    interface IInputEventBus
    {
        public void InvokeInputEvent (IInputManager sourceInputManager, string action, ushort state);

        public void SubscribeToEvent (string inputAction, EventHandler<object> handler);

        public void UnsubscribeFromEvent (string inputAction, EventHandler<object> eventHandler);
    }
}
