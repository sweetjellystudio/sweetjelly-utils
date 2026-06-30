using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SWeetJelly.Utils.Tests.EditMode
{
    public sealed class ArrayAndListExtensionsTest
    {
        [Test]
        public void IsNullOrEmpty_WhenListIsNullOrEmpty_ReturnsTrue()
        {
            IList<int> nullList = null;
            var emptyList = new List<int>();

            Assert.That(nullList.IsNullOrEmpty(), Is.True);
            Assert.That(emptyList.IsNullOrEmpty(), Is.True);
        }

        [Test]
        public void CollectionEquals_WhenItemsMatch_ReturnsTrue()
        {
            var first = new List<int> { 1, 2, 3 };
            var second = new List<int> { 1, 2, 3 };

            Assert.That(first.CollectionEquals(second), Is.True);
        }

        [Test]
        public void SubArray_ReturnsRequestedRange()
        {
            var source = new List<int> { 10, 20, 30, 40, 50 };

            var result = source.SubArray(index: 1, length: 3);

            Assert.That(result, Is.EqualTo(new[] { 20, 30, 40 }));
        }

        [Test]
        public void SubArray_WhenRangeIsInvalid_Throws()
        {
            var source = new List<int> { 10, 20, 30 };

            Assert.Throws<ArgumentOutOfRangeException>(() => source.SubArray(index: 2, length: 2));
        }
    }
}
