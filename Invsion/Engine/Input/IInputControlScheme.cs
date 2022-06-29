using System;
using System.Collections.Generic;
using System.Text;

namespace Invsion.Engine.Input
{
    public interface IInputControlScheme<T>
    {
        public string GetActionForInput (T input);
        public void BindActionToInput (T input, string action);
    }
}
