using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Engine.Utilities
{
    public static class DebugUtils
    {
        public static void DrawRect (SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Rectangle rect)
        {
            Texture2D _texture;
            _texture = new Texture2D(graphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.White });

            spriteBatch.Draw(_texture, new Rectangle(rect.Left, rect.Top, rect.Width, 1), Color.GreenYellow);
            spriteBatch.Draw(_texture, new Rectangle(rect.Right, rect.Top, 1, rect.Height), Color.GreenYellow);
            spriteBatch.Draw(_texture, new Rectangle(rect.Left, rect.Bottom, rect.Width, 1), Color.GreenYellow);
            spriteBatch.Draw(_texture, new Rectangle(rect.Left, rect.Top, 1, rect.Height), Color.GreenYellow);
        }
        public static void DrawRect (SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, Rect rect)
        {
            Texture2D _texture;
            _texture = new Texture2D(graphicsDevice, 1, 1);
            _texture.SetData(new Color[] { Color.White });

            spriteBatch.Draw(_texture, new Rectangle((int)rect.Left(), (int)rect.Top(), (int)rect.Width, 1), Color.GreenYellow);
            spriteBatch.Draw(_texture, new Rectangle((int)rect.Right(), (int)rect.Top(), 1, (int)rect.Height), Color.GreenYellow);
            spriteBatch.Draw(_texture, new Rectangle((int)rect.Left(), (int)rect.Bottom(), (int)rect.Width, 1), Color.GreenYellow);
            spriteBatch.Draw(_texture, new Rectangle((int)rect.Left(), (int)rect.Top(), 1, (int)rect.Height), Color.GreenYellow);
        }
    }
}
