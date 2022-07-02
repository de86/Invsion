using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace Invsion.Engine.Components
{
    interface IPositionComponent
    {
        public float GetX ();
        public float GetY ();
        public Vector2 GetPosition ();
        public void SetX (float x);
        public void SetY (float y);
        public void SetPosition (float x, float y);
        public void SetPosition (Vector2 position);
        public void Translate (float x, float y);
    }
}
