using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Src.Shared.Graphics
{
    class Sprite : DrawableObject
    {
        private Texture2D _texture;

        public Sprite (Texture2D texture, Vector2 position) : base (texture.Width, texture.Height, position)
        {
            _texture = texture;
        }



        public Sprite (Texture2D texture, Vector2 position, float alpha) : base (texture.Width, texture.Height, position, alpha)
        {
            _texture = texture;
        }



        public Sprite (Texture2D texture, Vector2 position, float alpha, Color color) : base (texture.Width, texture.Height, position, alpha, color)
        {
            _texture = texture;
        }



        public override void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _texture,
                Position - _positionOffset,
                _color * _alpha
            );
        }
    }
}
