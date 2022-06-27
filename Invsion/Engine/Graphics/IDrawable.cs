using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Engine.Graphics
{
    interface IDrawable
    {
        public void Draw (SpriteBatch spriteBatch);
    }
}
