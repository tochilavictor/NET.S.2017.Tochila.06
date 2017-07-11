using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLogic
{
    public enum SortingOrder { Growing, Waning }
    public enum SortingСriterion { Sum, Max, Min }
   
    public static class JuggedArraySort
    {
        /// <summary>
        /// Sorts strings of matrix in order specified by criterion and order
        /// </summary>
        /// <param name="array">jugged integer array</param>
        /// <param name="sortingCriterion">member of enum SortingСriterion</param>
        /// <param name="sortingOrder">member of enum SortingСriterion(growing,waning)</param>
        /// <exception cref="ArgumentException">invalid member of enum is used</exception>
        public static void BubbleSortMatrix(int[][] array, SortingСriterion sortingCriterion, SortingOrder sortingOrder)
        {
            ValidateJuggedArray(array);

            int numberOfStrings = array.Length;
            int[] criterionArray = new int[numberOfStrings];

            switch (sortingCriterion)
            {
                case SortingСriterion.Sum:
                    for (int i = 0; i < criterionArray.Length; i++)
                    {
                        for (int j = 0; j < array[i].Length; j++)
                            criterionArray[i] += array[i][j];
                    }
                    break;
                case SortingСriterion.Max:
                    for (int i = 0; i < criterionArray.Length; i++)
                    {
                        criterionArray[i] = array[i][0];
                        for (int j = 0; j < array[i].Length; j++)
                            if (criterionArray[i] < array[i][j]) criterionArray[i] = array[i][j];
                    }
                    break;
                case SortingСriterion.Min:
                    for (int i = 0; i < criterionArray.Length; i++)
                    {
                        criterionArray[i] = array[i][0];
                        for (int j = 0; j < array[i].Length; j++)
                            if (criterionArray[i] > array[i][j]) criterionArray[i] = array[i][j];
                    }
                    break;
                default: throw new ArgumentException($"Invalid {nameof(sortingCriterion)}");
            }

            if (sortingOrder == SortingOrder.Growing)
            {
                for (int i = 0; i < criterionArray.Length - 1; i++)
                {
                    for (int j = i + 1; j < criterionArray.Length; j++)
                    {
                        if (criterionArray[i] > criterionArray[j])
                        {
                            Swap(ref criterionArray[i], ref criterionArray[j]);
                            Swap(ref array[i], ref array[j]);
                        }
                    }
                }
            }

            else if (sortingOrder == SortingOrder.Waning)
            {
                for (int i = 0; i < criterionArray.Length - 1; i++)
                {
                    for (int j = i + 1; j < criterionArray.Length; j++)
                    {
                        if (criterionArray[i] < criterionArray[j])
                        {
                            Swap(ref criterionArray[i], ref criterionArray[j]);
                            Swap(ref array[i], ref array[j]);
                        }
                    }
                }
            }

            else throw new ArgumentException($"Invalid {nameof(sortingOrder)}");
        }
        private static void Swap(ref int l, ref int r)
        {
            int tmp = l;
            l = r;
            r = tmp;
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
