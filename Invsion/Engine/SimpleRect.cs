using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace Invsion.Engine
{
    public class SimpleRect
    {
        public float width = 0;
        public float height = 0;

        private float _x = 0;
        private float _y = 0;

        public SimpleRect (float x, float y, float width)
        {
            _x = x;
            _y = y;
            this.width = width;
            this.height = width;
        }

        public SimpleRect (float x, float y, float width, float height)
        {
            _x = x;
            _y = y;
            this.width = width;
            this.height = height;
        }



        public Vector2 GetPosition ()
        {
            return TopLeft();
        }



        public float Right ()
        {
            return _x + width;
        }



        public float Left ()
        {
            return _x;
        }



        public float Top ()
        {
            return _y;
        }



        public float Bottom ()
        {
            return _y + height;
        }



        public Vector2 TopRight ()
        {
            return new Vector2(
                Right(),
                Top()
            );
        }



        public Vector2 TopLeft ()
        {
            return new Vector2(
                Left(),
                Top()
            );
        }


        public Vector2 BottomRight ()
        {
            return new Vector2(
                Right(),
                Bottom()
            );
        }


        public Vector2 BottomLeft ()
        {
            return new Vector2(
                Left(),
                Bottom()
            );
        }


        public void CenterPositionAt (float x, float y)
        {
            _x = x - (width / 2);
            _y = y - (height / 2);
        }
    }
}
