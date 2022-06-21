using System;
using System.Collections.Generic;
using System.Text;

namespace Invsion.Src.Shared.Utilities
{
    class SwitchTimer
    {
        private float _duration;
        private float _counter;

        public SwitchTimer (float duration)
        {
            _duration = duration;
            _counter = 0;
        }

        public void Update (float input)
        {
            _counter += input / _duration;

            if (_counter >= 2)
            {
                _counter -= 2;
            }
        }

        public int GetValue ()
        {
            return (int)Math.Floor(_counter);
        }
    }
}
