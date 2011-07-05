using System;

namespace NSpec.NUnitAddin
{
    public class ArrayUtil
    {
        public static void Add<T>(ref T[] array, T item)
        {
            var length = array.Length;
            Array.Resize(ref array, length + 1);
            array[length] = item;
        }
    }
}