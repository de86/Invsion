using System;
using System.Collections.Generic;
using System.Text;

namespace Invsion.Engine.Settings
{
    public interface ISetting
    {
        public string GetKey ();
        public string GetRawValue ();

        public void SetValue (string value);

        public void Reset ();
    }
}
