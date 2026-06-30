using NUnit.Framework;
using UnityEngine;

namespace SWeetJelly.Utils.Tests.EditMode
{
    public sealed class TransformExtensionsTest
    {
        [Test]
        public void ResetLocal_ResetsLocalTransformAndReturnsTransform()
        {
            var gameObject = new GameObject("ResetLocal");

            try
            {
                var transform = gameObject.transform;
                transform.localPosition = new Vector3(1f, 2f, 3f);
                transform.localRotation = Quaternion.Euler(10f, 20f, 30f);
                transform.localScale = new Vector3(2f, 3f, 4f);

                var result = transform.ResetLocal();

                Assert.That(result, Is.SameAs(transform));
                Assert.That(transform.localPosition, Is.EqualTo(Vector3.zero));
                Assert.That(transform.localRotation, Is.EqualTo(Quaternion.identity));
                Assert.That(transform.localScale, Is.EqualTo(Vector3.one));
            }
            finally
            {
                Object.DestroyImmediate(gameObject);
            }
        }

        [Test]
        public void TryGetChild_WhenIndexExists_ReturnsChild()
        {
            var parent = new GameObject("Parent");
            var child = new GameObject("Child");

            try
            {
                child.transform.SetParent(parent.transform);

                Assert.That(parent.transform.TryGetChild(0), Is.SameAs(child.transform));
            }
            finally
            {
                Object.DestroyImmediate(child);
                Object.DestroyImmediate(parent);
            }
        }

        [Test]
        public void TryGetChild_WhenIndexDoesNotExist_ReturnsNull()
        {
            var parent = new GameObject("Parent");

            try
            {
                Assert.That(parent.transform.TryGetChild(0), Is.Null);
            }
            finally
            {
                Object.DestroyImmediate(parent);
            }
        }
    }
}
