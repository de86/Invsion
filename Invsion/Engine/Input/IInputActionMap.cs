using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace Invsion.Engine.Input
{
    interface IInputActionMap
    {
        public void BindActionToInput (Action action, Buttons button);

        public void BindActionToInput (Action action, Keys key);

        public void ExecuteActionForInput (Buttons button);

        public void ExecuteActionForInput (Keys key);
    }
}
