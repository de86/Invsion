using System;
using System.Collections.Generic;
using System.Text;

namespace Invsion.Src.Input
{
    interface IInputManager
    {
        public void SetActiveInputActionMap (IInputActionMap inputController);

        public void ProcessInput ();
    }
}
