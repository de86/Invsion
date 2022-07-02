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
    }
}
