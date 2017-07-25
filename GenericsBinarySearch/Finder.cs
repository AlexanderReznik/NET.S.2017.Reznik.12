using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace GenericsBinarySearch
{
    public class Finder
    {
        /// <summary>
        /// Method for finding
        /// </summary>
        /// <typeparam name="T">param</typeparam>
        /// <param name="array">Array, where the searching is performed</param>
        /// <param name="key">Elem to find</param>
        /// <param name="comparison">How to find</param>
        /// <returns>Index, if array has key. null else</returns>
        public static int? BinarySearch<T>(T[] array, T key, Comparison<T> comparison)
        {
            Check(array, key, ref comparison);
            if (array.Length == 0 || comparison(array[0],key) > 0 || comparison(array[array.Length - 1], key) < 0) return null;

            return Find(array, key, comparison);
        }

        /// <summary>
        /// Method for finding
        /// </summary>
        /// <typeparam name="T">param</typeparam>
        /// <param name="array">Array, where the searching is performed</param>
        /// <param name="key">Elem to find</param>
        /// <param name="comparer">How to find</param>
        /// <returns>Index, if array has key. null else</returns>
        public static int? BinarySearch<T>(T[] array, T key, IComparer<T> comparer)
        {
            if (comparer == null) throw new ArgumentNullException();
            return BinarySearch(array, key, comparer.Compare);
        }

        /// <summary>
        /// Method for finding
        /// </summary>
        /// <typeparam name="T">param</typeparam>
        /// <param name="array">Array, where the searching is performed</param>
        /// <param name="key">Elem to find</param>
        /// <returns>Index, if array has key. null else</returns>
        public static int? BinarySearch<T>(T[] array, T key)
        {
            return BinarySearch(array, key, (Comparison<T>)null);
        }

        private static void Check<T>(T[] array, T key, ref Comparison<T> comparison)
        {
            if (array == null) throw new ArgumentNullException();
            if (comparison == null) comparison = Comparer<T>.Default.Compare;
        }

        private static int? Find<T>(T[] array, T key, Comparison<T> comparison)
        {
            int left = 0;
            int right = array.Length;

            while (left < right)
            {
                int middle = left + (right - left) / 2;

                if (comparison(array[middle], key) == 0) return middle;
                if (comparison(array[middle], key) < 0) left = middle + 1;
                else right = middle;
            }

            return null;
        }
    }
}
