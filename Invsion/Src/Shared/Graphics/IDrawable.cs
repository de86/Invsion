using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Src.Shared.Graphics
{
    interface IDrawable
    {
        public void Draw (SpriteBatch spriteBatch);
    }
}
