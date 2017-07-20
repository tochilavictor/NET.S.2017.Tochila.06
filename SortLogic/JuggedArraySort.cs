using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLogic
{
    public interface IComparer
    {
        int CompareTo(int[] lhs, int[] rhs);
    }
    /// <summary>
    /// implements delegate method using interface method
    /// </summary>
    public static class JuggedArraySort1
    {
        /// <summary>
        /// Bubble sorts jugged array using Icomparer
        /// </summary>
        /// <param name="array">array</param>
        /// <param name="ic">comparer privides comparing logic</param>
        public static void Sort(int[][] array, IComparer ic)
        {
            ValidateArray(array);
            if(ic==null) throw new ArgumentNullException();
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (ic.CompareTo(array[i], array[j]) == 1)
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }
        /// <summary>
        /// Bubble sorts jugged array using delegate
        /// </summary>
        /// <param name="array">array</param>
        /// <param name="compasion">delegate provides comparing logic</param>
        public static void Sort(int[][] array, Func<int[], int[], int> compasion)
        {
            ValidateArray(array);
            if (compasion == null) throw new ArgumentNullException();
            Sort(array, new ComparisionToComparer(compasion));
        }
        private static void Swap(ref int[] l, ref int[] r)
        {
            int[] tmp = l;
            l = r;
            r = tmp;
        }

        private static void ValidateArray(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException("Empty array");
        }

        private class ComparisionToComparer : IComparer
        {
            private Func<int[], int[], int> comparer;
            public ComparisionToComparer(Func<int[], int[], int> comparer)
            {
                this.comparer = comparer;
            }

            public int CompareTo(int[] lhs, int[] rhs)
            {
                return comparer(lhs, rhs);
            }
        }
    }
    /// <summary>
    /// implements interface method using delegate method
    /// </summary>
    public static class JuggedArraySort2
    {
        /// <summary>
        /// Bubble sorts jugged array using Icomparer
        /// </summary>
        /// <param name="array">array</param>
        /// <param name="ic">comparer privides comparing logic</param>
        public static void Sort(int[][] array, IComparer ic)
        {
            ValidateArray(array);
            if (ic == null) throw new ArgumentNullException();
            Sort(array, ic.CompareTo);
        }
        /// <summary>
        /// Bubble sorts jugged array using delegate
        /// </summary>
        /// <param name="array">array</param>
        /// <param name="compasion">delegate provides comparing logic</param>
        public static void Sort(int[][] array, Func<int[], int[], int> compasion)
        {
            ValidateArray(array);
            if (compasion == null) throw new ArgumentNullException();
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (compasion(array[i],array[j])==1)
                    {
                        Swap(ref array[i], ref array[j]);
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

        private static void ValidateArray(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException("Empty array");
        }
    }
}
