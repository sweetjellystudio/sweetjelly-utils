namespace SWeetJelly.Utils.Tests.PlayMode
{
    using System;
    using System.Collections;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using UnityEngine;
    using UnityEngine.TestTools;
    using UnityEngine.UI;

    public sealed class UtilsRuntimeContractTest
    {
        [UnityTest]
        public IEnumerator ResourceOperation_AsTaskCompletesBeforeAndAfterCompletion()
        {
            var operation = Resources.LoadAsync<TextAsset>("utils-verification-missing-resource");
            var task = operation.AsTask();
            for (var frame = 0; frame < 120 && !task.IsCompleted; frame++) yield return null;
            Assert.That(task.IsCompleted, Is.True);
            Assert.That(task.IsFaulted, Is.False);
            var completedTask = operation.AsTask();
            for (var frame = 0; frame < 120 && !completedTask.IsCompleted; frame++) yield return null;
            Assert.That(completedTask.IsCompleted, Is.True);
        }

        [UnityTest]
        public IEnumerator DelayedDisabler_DisablesAndCanBeEnabledAgain()
        {
            var holder = new GameObject("Utils delayed disabler verification");
            try
            {
                holder.AddComponent<DelayedObjectDisabler>().delay = 0;
                for (var frame = 0; frame < 10 && holder.activeSelf; frame++) yield return null;
                Assert.That(holder.activeSelf, Is.False);
                holder.SetActive(true);
                for (var frame = 0; frame < 10 && holder.activeSelf; frame++) yield return null;
                Assert.That(holder.activeSelf, Is.False);
            }
            finally { UnityEngine.Object.Destroy(holder); }
        }

        [UnityTest]
        public IEnumerator Forget_ReportsOriginalExceptionToHandler()
        {
            Exception observed = null;
            var original = new InvalidOperationException("utils forget regression");
            Task.FromException(original).Forget(error => observed = error);
            yield return null;
            Assert.That(observed, Is.SameAs(original));
        }

        [UnityTest]
        public IEnumerator GraphicAlpha_PreservesGraphicAndRgb()
        {
            var holder = new GameObject("Utils graphic verification", typeof(RectTransform), typeof(CanvasRenderer));
            try
            {
                var image = holder.AddComponent<Image>();
                image.color = new Color(0.1f, 0.2f, 0.3f, 1);
                Assert.That(image.SetAlpha(0.4f), Is.SameAs(image));
                Assert.That(image.color, Is.EqualTo(new Color(0.1f, 0.2f, 0.3f, 0.4f)));
                yield return null;
            }
            finally { UnityEngine.Object.Destroy(holder); }
        }
    }
}
