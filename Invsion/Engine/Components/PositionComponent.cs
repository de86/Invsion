using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace Invsion.Engine.Components
{
    public class PositionComponent : IPositionComponent
    {
        private float _x;
        private float _y;



        public PositionComponent (float x, float y)
        {
            _x = x;
            _y = y;
        }

        public PositionComponent (Vector2 position)
        {
            _x = position.X;
            _y = position.Y;
        }



        public float GetX ()
        {
            return _x;
        }



        public float GetY ()
        {
            return _y;
        }



        public Vector2 GetPosition ()
        {
            return new Vector2(_x, _y);
        }



        public void SetX (float x)
        {
            _x = x;
        }


        public void SetY (float y)
        {
            _y = y;
        }



        public void SetPosition (float x, float y)
        {
            _x = x;
            _y = y;
        }



        public void SetPosition (Vector2 position)
        {
            _x = position.X;
            _y = position.Y;
        }
    }
}
