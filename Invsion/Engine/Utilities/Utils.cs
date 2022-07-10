using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Engine.Utilities
{
    public static class Utils
    {


        public static void Noop ()
        {
            return;
        }


        /// <summary>
        /// Method GetCombinedArray Returns a new array containing all items in the provided arrays.
        /// </summary>
        /// <typeparam name="T">The type of the arrays to be combined</typeparam>
        /// <param name="a">The first array</param>
        public static T[] GetCombinedArray<T> (params T[][] arrays)
        {
            var combinedList = new List<T>();

            foreach (T[] array in arrays)
            {
                combinedList.AddRange(array);
            }

            return combinedList.ToArray();
        }


        /// <summary>
        /// Method ConstrainPositionToWorldBounds constrains the position of a first Rect
        /// to remain within the boundaries of a second Rect
        /// </summary>
        /// <param name="rect">The Rect instance whose position we want to constrain</param>
        /// <param name="boundary">The Rect instance to be used as a boundary to constrain rect</param>
        public static void ConstrainPositionToWorldBounds (Rect rect, Rect boundary)
        {
            ;
            if (rect.Right() > boundary.Right())
            {
                rect.SetRight(boundary.Right());
            }
            else if (rect.Left() < boundary.Left())
            {
                rect.SetLeft(boundary.Left());
            }

            if (rect.Top() < boundary.Top())
            {
                rect.SetTop(boundary.Top());
            }
            else if (rect.Bottom() > boundary.Bottom())
            {
                rect.SetBottom(boundary.Bottom());
            }
        }
    }
}
