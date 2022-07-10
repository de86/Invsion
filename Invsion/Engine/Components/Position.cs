using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace Invsion.Engine.Components
{
    public class Position : IPosition
    {
        internal Vector2 _position = Vector2.Zero;

        public float X { 
            get
            {
                return _position.X;
            }
            set
            {
                _position.X = value;
            }
        }
        public float Y
        {
            get
            {
                return _position.Y;
            }
            set
            {
                _position.Y = value;
            }
        }


        public Position (float x, float y)
        {
            _position.X = x;
            _position.Y = y;
        }
        public Position (Vector2 position)
        {
            _position = position;
        }


        public Vector2 GetPosition ()
        {
            return new Vector2(_position.X, _position.Y);
        }
        public void SetPosition (float x, float y)
        {
            _position.X = x;
            _position.Y = y;
        }
        public void SetPosition (Vector2 position)
        {
            _position = position;
        }
        public void Translate (float x, float y)
        {
            _position.X += x;
            _position.Y += y;
        }
        public void Translate (Vector2 position)
        {
            _position.X += position.X;
            _position.Y += position.Y;
        }
    }
}
