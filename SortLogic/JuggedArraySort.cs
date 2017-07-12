using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLogic
{  
    public static class JuggedArraySort
    {
        public interface IComparer
        {
            int CompareTo(int[] lhs, int[] rhs);
        }
        public static class BubbleSort
        {
            public static void Sort(int[][] array, IComparer ic, bool ifAscendingOrder = true)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (ifAscendingOrder ? ic.CompareTo(array[i], array[j]) == 1 : ic.CompareTo(array[i], array[j]) == -1)
                        {
                            var tmp = array[i];
                            array[i] = array[j];
                            array[j] = tmp;
                        }
                    }
                }
            }
        }
        private static void Swap(ref int[] l, ref int[] r)
        {
            int[] tmp = l;
            l = r;
            r = tmp;
        }
        static void ValidateJuggedArray(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException("Empty array");
            foreach (int[] matrixString in array)
            {
                if (matrixString == null)
                    throw new ArgumentNullException();
                if (matrixString.Length == 0)
                    throw new ArgumentException("Empty array");
            }
        }
    }
}
