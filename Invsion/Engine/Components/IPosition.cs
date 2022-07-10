using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace Invsion.Engine.Components
{
    interface IPosition
    {
        public void SetPosition (float x, float y);
        public void SetPosition (Vector2 position);
    }
}
