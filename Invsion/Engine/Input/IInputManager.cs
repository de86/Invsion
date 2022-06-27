using System;
using System.Collections.Generic;
using System.Text;

namespace Invsion.Engine.Input
{
    interface IInputManager
    {
        public void SetActiveInputActionMap (IInputActionMap inputController);

        public void ProcessInput ();
    }
}
