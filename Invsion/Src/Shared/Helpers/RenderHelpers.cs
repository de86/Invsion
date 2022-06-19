using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Src.Shared.Helpers
{
    public static class RenderHelpers
    {
        public static Vector2 ScreenCentre (Texture2D t, int resolutionWidth, int resolutionHeight)
        {
            return new Vector2 (
                (resolutionWidth / 2) - (t.Width / 2),
                (resolutionHeight / 2) - (t.Height / 2)
            );
        }
    }
}
