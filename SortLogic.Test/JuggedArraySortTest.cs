using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SortLogic;

namespace SortLogic.Test
{
    [TestFixture()]
    public class JuggedArraySortTest
    {
        [TestCase(
            new int[] { 10, 40, 20 },
            new int[] { 70, 123, -150 },
            new int[] { 0 },
            new int[] { 50, 50 },ExpectedResult = true)]
        public bool BubbleSort_SumAscendingCriterium_PositiveTest(params int[][] array)
        {
            JuggedArraySort.BubbleSort.Sort(array,new JuggedSum());
            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i].Sum() > array[i + 1].Sum()) return false;
            }
            return true;
        }

        [TestCase(
            new int[] { 10, 40, 20 },
            new int[] { 70, 123, -150 },
            new int[] { 0 },
            new int[] { 50, 50 }, ExpectedResult = true)]
        public bool BubbleSort_SumDescendingCriterium_PositiveTest(params int[][] array)
        {
            JuggedArraySort.BubbleSort.Sort(array, new JuggedSum(),false);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].Sum() < array[i + 1].Sum()) return false;
            }
            return true;
        }

        [TestCase(
            new int[] { 10, 40, 20 },
            new int[] { 70, 123, -150 },
            new int[] { 0 },
            new int[] { 50, 50 }, ExpectedResult = true)]
        public bool BubbleSort_MaxAscendingCriterium_PositiveTest(params int[][] array)
        {
            JuggedArraySort.BubbleSort.Sort(array, new JuggedMax());
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].Max() > array[i + 1].Max()) return false;
            }
            return true;
        }

        [TestCase(
            new int[] { 10, 40, 20 },
            new int[] { 70, 123, -150 },
            new int[] { 0 },
            new int[] { 50, 50 }, ExpectedResult = true)]
        public bool BubbleSort_MaxDescendingCriterium_PositiveTest(params int[][] array)
        {
            JuggedArraySort.BubbleSort.Sort(array, new JuggedMax(),false);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].Max() < array[i + 1].Max()) return false;
            }
            return true;
        }

        [TestCase(
            new int[] { 10, 40, 20 },
            new int[] { 70, 123, -150 },
            new int[] { 0 },
            new int[] { 50, 50 }, ExpectedResult = true)]
        public bool BubbleSort_MinAscendingCriterium_PositiveTest(params int[][] array)
        {
            JuggedArraySort.BubbleSort.Sort(array, new JuggedMin());
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].Min() > array[i + 1].Min()) return false;
            }
            return true;
        }

        [TestCase(
            new int[] { 10, 40, 20 },
            new int[] { 70, 123, -150 },
            new int[] { 0 },
            new int[] { 50, 50 }, ExpectedResult = true)]
        public bool BubbleSort_MinDescendingCriterium_PositiveTest(params int[][] array)
        {
            JuggedArraySort.BubbleSort.Sort(array, new JuggedMin(), false);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].Min() < array[i + 1].Min()) return false;
            }
            return true;
        }
    }
    public class JuggedSum : JuggedArraySort.IComparer
    {
        public int CompareTo(int[] lhs, int[] rhs)
        {
            if (lhs.Sum() == rhs.Sum()) return 0;
            if (lhs.Sum() > rhs.Sum()) return 1;
            return -1;
        }
    }
    public class JuggedMax : JuggedArraySort.IComparer
    {
        public int CompareTo(int[] lhs, int[] rhs)
        {
            if (lhs.Max() == rhs.Max()) return 0;
            if (lhs.Max() > rhs.Max()) return 1;
            return -1;
        }
    }
    public class JuggedMin : JuggedArraySort.IComparer
    {
        public int CompareTo(int[] lhs, int[] rhs)
        {
            if (lhs.Min() == rhs.Min()) return 0;
            if (lhs.Min() > rhs.Min()) return 1;
            return -1;
        }
    }
}
