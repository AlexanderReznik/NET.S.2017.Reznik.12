using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static GenericsBinarySearch.Finder;

namespace GenericsBinarySearch.NUnitTest
{
    public class FinderTests
    {
        [TestCase(new int[] { 1, 16, 78, 156, 177, 200, 544 }, 1, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 16, 78, 156, 177, 200, 544 }, 16, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 16, 78, 156, 177, 200, 544 }, 78, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 16, 78, 156, 177, 200, 544 }, 156, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 16, 78, 156, 177, 200, 544 }, 177, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 16, 78, 156, 177, 200, 544 }, 200, ExpectedResult = 5)]
        [TestCase(new int[] { 1, 16, 78, 156, 177, 200, 544 }, 544, ExpectedResult = 6)]
        [TestCase(new int[] { 1, 16, 78, 156, 177, 200, 544 }, -15, ExpectedResult = null)]
        [TestCase(new int[] { 1, 16, 78, 156, 177, 200, 544 }, 54, ExpectedResult = null)]
        [TestCase(new int[] { 1, 16, 78, 156, 177, 200, 544 }, 545, ExpectedResult = null)]
        public int? BinarySearch_Int(int[] array, int key)
        {
            return BinarySearch(array, key);
        }

        [TestCase(new string[] { "Alex", "Dima", "Igor", "Stas", "Valera" }, "Stas", ExpectedResult = 3)]
        [TestCase(new string[] { "Alex", "Dima", "Igor", "Stas", "Valera" }, "Dima", ExpectedResult = 1)]
        [TestCase(new string[] { "Alex", "Dima", "Igor", "Stas", "Valera" }, "Valera", ExpectedResult = 4)]
        [TestCase(new string[] { "Alex", "Dima", "Igor", "Stas", "Valera" }, "Volodya", ExpectedResult = null)]
        public int? BinarySearch_String(string[] array, string key)
        {
            return BinarySearch(array, key, (string lhs, string rhs) => string.Compare(lhs, rhs, StringComparison.CurrentCulture));
        }
    }
}
