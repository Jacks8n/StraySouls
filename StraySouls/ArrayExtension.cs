using System;

namespace StraySouls
{
    public static class ArrayExtension
    {
        public static void Shuffle<T>(this T[] arr)
        {
            Random rand = new Random();
            int selection, last = arr.Length - 1;
            T temp;

            for (int i = 0; i < arr.Length; i++, last--)
            {
                selection = rand.Next(0, last);
                temp = arr[last];
                arr[last] = arr[selection];
                arr[selection] = temp;
            }
        }
    }
}
