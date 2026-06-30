using System;
using NUnit.Framework;

namespace SWeetJelly.Utils.Tests.EditMode
{
    public sealed class StringExtensionsTest
    {
        [Test]
        public void BlankChecks_HandleNullEmptyAndWhitespace()
        {
            string nullValue = null;

            Assert.That(nullValue.IsBlank(), Is.True);
            Assert.That(string.Empty.IsBlank(), Is.True);
            Assert.That("   ".IsBlank(), Is.True);
            Assert.That("SweetJelly".IsBlank(), Is.False);
        }

        [Test]
        public void OrEmpty_WhenValueIsNull_ReturnsEmptyString()
        {
            string value = null;

            Assert.That(value.OrEmpty(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Slice_WithPositiveAndNegativeEndIndex_ReturnsExpectedSubstring()
        {
            const string value = "SweetJelly";

            Assert.That(value.Slice(0, 5), Is.EqualTo("Sweet"));
            Assert.That(value.Slice(5, -1), Is.EqualTo("Jell"));
        }

        [Test]
        public void Slice_WhenValueIsBlank_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => string.Empty.Slice(0, 1));
        }
    }
}
