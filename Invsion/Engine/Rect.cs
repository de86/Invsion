using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Invsion.Engine.Components;

namespace Invsion.Engine
{
    public class Rect : ISimpleShape
    {
        public float Width = 0;
        public float Height = 0;

        private Position _position;

        public Rect (Position position, float width)
        {
            _position = position;
            Width = width;
            Height = width;
        }



        public Rect (Position position, float width, float height)
        {
            _position = position;
            Width = width;
            Height = height;
        }



        public Rect (Vector2 position, float width)
        {
            _position = new Position(position);
            Width = width;
            Height = width;
        }



        public Rect (Vector2 position, float width, float height)
        {
            _position = new Position(position);
            Width = width;
            Height = height;
        }


        public Vector2 GetPosition ()
        {
            return TopLeft();
        }



        public float Right ()
        {
            return _position.X + Width;
        }



        public float Left ()
        {
            return _position.X;
        }



        public float Top ()
        {
            return _position.Y;
        }



        public float Bottom ()
        {
            return _position.Y + Height;
        }



        public Vector2 TopRight ()
        {
            return new Vector2(
                Right(),
                Top()
            );
        }



        public Vector2 TopLeft ()
        {
            return new Vector2(
                Left(),
                Top()
            );
        }



        public Vector2 BottomRight ()
        {
            return new Vector2(
                Right(),
                Bottom()
            );
        }



        public Vector2 BottomLeft ()
        {
            return new Vector2(
                Left(),
                Bottom()
            );
        }



        public void SetLeft (float xLeft)
        {
            _position.X = xLeft;
        }



        public void SetRight (float xRight)
        {
            _position.X = xRight - Width;
        }



        public void SetTop (float yTop)
        {
            _position.Y = yTop;
        }



        public void SetBottom (float yBottom)
        {
            _position.Y = yBottom - Height;
        }



        public void CenterPositionAt (float x, float y)
        {
            _position.X = x - (Width / 2);
            _position.Y = y - (Height / 2);
        }



        public bool Contains (float x, float y)
        {
            return (
                _position.X <= x
                && x < (_position.X + Width)
                && _position.Y <= y
                && y < (_position.Y + Height));
        }
    }
}
