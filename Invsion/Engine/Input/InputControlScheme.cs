using System;
using System.Collections.Generic;
using System.Text;

namespace Invsion.Engine.Input
{
    public class InputControlScheme<T> : IInputControlScheme<T>
    {
        private Dictionary<T, string> _keyActionBindings;

        public InputControlScheme ()
        {
            _keyActionBindings = new Dictionary<T, string>();
        }



        public InputControlScheme (Dictionary<T, string> keyActionBindings) {
            _keyActionBindings = keyActionBindings;
        }



        public string GetActionForInput (T input)
        {
            string action;
            _keyActionBindings.TryGetValue(input, out action);

            if (action == null)
                throw new KeyNotFoundException(input.ToString());

            return action;
        }



        public void BindActionToInput (T input, string action)
        {
            if (_keyActionBindings.ContainsKey(input))
            {
                _keyActionBindings[input] = action;
            } else
            {
                _keyActionBindings.Add(input, action);
            }
        }
    }
}
