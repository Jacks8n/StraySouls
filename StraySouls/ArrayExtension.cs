using System;
using System.Collections.Generic;

namespace StraySouls
{
    public static class ArrayExtension
    {
        public static void Shuffle<T>(this List<T> arr)
        {
            Random rand = new Random();
            int selection, last = arr.Count - 1;
            T temp;

            for (int i = 0; i < arr.Count; i++, last--)
            {
                selection = rand.Next(0, last);
                temp = arr[last];
                arr[last] = arr[selection];
                arr[selection] = temp;
            }
        }
    }
}
