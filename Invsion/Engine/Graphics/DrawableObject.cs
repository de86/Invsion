using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Engine.Graphics
{
    public abstract class DrawableObject : IDrawable
    {
        public Vector2 Position { get; set; }
        public float Width;
        public float Height;

        protected Vector2 _positionOffset;
        protected Color _color;
        protected float _alpha;


        public DrawableObject (float width, float height, Vector2 position)
        {
            Position = position;
            _alpha = 1;
            _color = Color.White;
            Width = width;
            Height = height;
            _positionOffset = new Vector2(0, 0);
        }



        public DrawableObject (float width, float height, Vector2 position, float alpha)
        {
            Position = position;
            _alpha = alpha;
            _color = Color.White;
            Width = width;
            Height = height;
            _positionOffset = new Vector2(0, 0);
        }



        public DrawableObject (float width, float height, Vector2 position, float alpha, Color color)
        {
            Position = position;
            _alpha = alpha;
            _color = color;
            Width = width;
            Height = height;
            _positionOffset = new Vector2(0, 0);
        }



        public abstract void Draw (SpriteBatch spriteBatch);



        public void UpdateAlpha (float alpha)
        {
            _alpha = alpha;
        }



        public void UpdatePosition (Vector2 position)
        {
            Position = position;
        }



        public void UpdatePosition (float x, float y)
        {
            Position = new Vector2(x, y);
        }



        public void UpdateColor (Color color)
        {
            _color = color;
        }



        public Vector2 GetSize ()
        {
            return new Vector2(Position.X, Position.Y);
        }



        public void SetOriginCentre ()
        {
            _positionOffset = new Vector2(Width / 2, Height / 2);
        }
    }
}
