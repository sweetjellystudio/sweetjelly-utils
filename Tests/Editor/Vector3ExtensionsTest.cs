using NUnit.Framework;
using UnityEngine;

namespace SWeetJelly.Utils.Tests.EditMode
{
    public sealed class Vector3ExtensionsTest
    {
        [Test]
        public void With_ReplacesOnlyProvidedComponents()
        {
            var vector = new Vector3(1f, 2f, 3f);

            var result = vector.With(y: 9f);

            Assert.That(result, Is.EqualTo(new Vector3(1f, 9f, 3f)));
        }

        [Test]
        public void ComponentDivide_SkipsZeroDivisors()
        {
            var value = new Vector3(10f, 20f, 30f);
            var divisor = new Vector3(2f, 0f, 5f);

            var result = value.ComponentDivide(divisor);

            Assert.That(result, Is.EqualTo(new Vector3(5f, 20f, 6f)));
        }

        [Test]
        public void InRangeOf_UsesDistanceRange()
        {
            var origin = Vector3.zero;

            Assert.That(origin.InRangeOf(new Vector3(3f, 4f, 0f), 5f), Is.True);
            Assert.That(origin.InRangeOf(new Vector3(3f, 4f, 0f), 4.9f), Is.False);
        }
    }
}
