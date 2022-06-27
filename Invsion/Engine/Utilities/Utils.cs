using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Engine.Utilities
{
    public static class Utils
    {
        public static bool Assert (bool condition, Exception e)
        {
            if (condition) return true;

            throw e;
        }


        public static void Noop ()
        {
            return;
        }



        public static Vector2 GetTextureCenter (Texture2D texture)
        {
            return new Vector2(
                texture.Width / 2,
                texture.Height / 2
            );
        }



        public static long GetNowInMillis ()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }
    }
}
