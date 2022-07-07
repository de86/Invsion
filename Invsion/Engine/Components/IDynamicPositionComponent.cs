using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace Invsion.Engine.Components
{
    interface IDynamicPositionComponent : IPositionComponent
    {
        public void Translate (float x, float y);
        public void AccelerateAndMove (Vector2 moveVector, float maxSpeed, float delta);
        public void SetAcceleration (float accelerationX, float accelerationY);
        public void SetDeceleration (float deceleration);
    }
}
