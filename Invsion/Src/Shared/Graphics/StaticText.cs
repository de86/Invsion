using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Src.Shared.Graphics
{
    public class StaticText : DrawableObject
    {
        private SpriteFont _font;
        private string _text;



        public StaticText (string text, SpriteFont font, Vector2 position) : base (0, 0, position)
        {
            _text = text;
            _font = font;

            var size = _font.MeasureString(_text);
            Width = size.X;
            Height = size.Y;
        }



        public StaticText (string text, SpriteFont font, Vector2 position, int alpha) : base (0, 0, position, alpha)
        {
            _text = text;
            _font = font;

            var size = _font.MeasureString(_text);
            Width = size.X;
            Height = size.Y;
        }



        public StaticText (string text, SpriteFont font, Vector2 position, int alpha, Color color) : base (0, 0, position, alpha, color)
        {
            _text = text;
            _font = font;

            var size = _font.MeasureString(_text);
            Width = size.X;
            Height = size.Y;
        }



        public override void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                _font,
                _text,
                Position - _positionOffset,
                _color * _alpha
            );
        }
    }
}
