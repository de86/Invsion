using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Engine
{
    public interface ISimpleShape
    {
        public Vector2 GetPosition ();
        public float Right ();
        public float Left ();
        public float Top ();
        public float Bottom ();
        public Vector2 TopRight ();
        public Vector2 TopLeft ();
        public Vector2 BottomRight ();
        public Vector2 BottomLeft ();
        public void CenterPositionAt (float x, float y);
    }
}
