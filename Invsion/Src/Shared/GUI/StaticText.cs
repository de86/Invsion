using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Src.Shared.GUI
{
    public class StaticText
    {
        private SpriteFont _font;
        private string _text;
        private Vector2 _position;
        private Vector2 _positionOffset;
        private Color _color;
        private int _alpha;
        private Vector2 _size;


        public StaticText (string text, SpriteFont font, Vector2 position)
        {
            _text = text;
            _font = font;
            _position = position;
            _alpha = 1;
            _color = Color.White;
            _size = _font.MeasureString(_text);
            _positionOffset = new Vector2(0, 0);
        }



        public StaticText (string text, SpriteFont font, Vector2 position, int alpha)
        {
            _text = text;
            _font = font;
            _position = position;
            _alpha = alpha;
            _color = Color.White;
            _size = _font.MeasureString(_text);
            _positionOffset = new Vector2(0, 0);
        }



        public StaticText (string text, SpriteFont font, Vector2 position, int alpha, Color color)
        {
            _text = text;
            _font = font;
            _position = position;
            _alpha = alpha;
            _color = color;
            _size = _font.MeasureString(_text);
            _positionOffset = new Vector2(0, 0);
        }



        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                _font,
                _text,
                _position - _positionOffset,
                _color * _alpha
            );
        }



        public void UpdateAlpha (int alpha)
        {
            _alpha = alpha;
        }

    

        public void UpdatePosition (Vector2 position)
        {
            _position = position;
        }



        public void UpdatePosition (float x, float y)
        {
            _position.X = x;
            _position.Y = y;
        }



        public void UpdateColor (Color color)
        {
            _color = color;
        }




        public Vector2 GetSize ()
        {
            return new Vector2(_size.X, _size.Y);
        }



        public void SetOriginCentre ()
        {
            _positionOffset = new Vector2(_size.X / 2, _size.Y / 2);
        }
    }
}
