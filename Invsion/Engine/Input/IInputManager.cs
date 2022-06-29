using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace Invsion.Engine.Input
{
    public interface IInputManager
    {
        public void SetKeyboardControlScheme (IInputControlScheme<Keys> keyboardControlScheme);

        public void ProcessInput ();
    }
}
