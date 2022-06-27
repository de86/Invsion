using System;
using System.Collections.Generic;

using static Invsion.Engine.Utilities.Utils;

using Microsoft.Xna.Framework.Input;

namespace Invsion.Engine.Input
{
    class InputActionMap : IInputActionMap
    {
        private Dictionary<Buttons, Action> _buttonInputActionMap;
        private Dictionary<Keys, Action> _keyInputActionMap;
        


        public InputActionMap ()
        {
            _buttonInputActionMap = new Dictionary<Buttons, Action>();
            _keyInputActionMap = new Dictionary<Keys, Action>();
        }


        public void BindActionToInput(Action action, Buttons button)
        {
            _buttonInputActionMap.Add(button, action);
        }



        public void BindActionToInput (Action action, Keys key)
        {
            _keyInputActionMap.Add(key, action);
        }



        public void ExecuteActionForInput (Buttons button)
        {
            Action Action;
            if (_buttonInputActionMap.TryGetValue(button, out Action))
            {
                Action();
            } 
            else
            {
                Noop();
            }
        }



        public void ExecuteActionForInput (Keys key)
        {
            Action Action;
            if (_keyInputActionMap.TryGetValue(key, out Action))
            {
                Action();
            }
            else
            {
                Noop();
            }
        }
    }
}
