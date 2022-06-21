using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Src.Shared.Helpers
{
    public static class RenderHelpers
    {
        public static Vector2 ScreenCentre (int width, int height, int resolutionWidth, int resolutionHeight)
        {
            return new Vector2 (
                (resolutionWidth / 2) - (width / 2),
                (resolutionHeight / 2) - (height / 2)
            );
        }

        public static Vector2 ScreenCentre (float width, float height, int resolutionWidth, int resolutionHeight)
        {
            return ScreenCentre(
                (int)width,
                (int)height,
                resolutionWidth,
                resolutionHeight
            );
        }
    }
}
