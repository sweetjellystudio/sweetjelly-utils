namespace SWeetJelly.Utils.Tests.EditMode
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Unity.Mathematics;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.TestTools;

    public sealed class UtilsContractRegressionTest
    {
        [Test]
        public void Dictionary_RoundTripPreservesEntries()
        {
            var dictionary = new SerializableDictionary<string, int> { ["one"] = 1, ["two"] = 2 };
            dictionary.OnBeforeSerialize();
            dictionary.Clear();
            dictionary.OnAfterDeserialize();
            Assert.That(dictionary, Is.EqualTo(new Dictionary<string, int> { ["one"] = 1, ["two"] = 2 }));
        }

        [Test]
        public void Dictionary_MismatchedLists_DoesNotThrowIndexException()
        {
            var dictionary = new SerializableDictionary<string, int>();
            typeof(SerializableDictionary<string, int>).GetField("keys", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(dictionary, new List<string> { "one", "two" });
            typeof(SerializableDictionary<string, int>).GetField("values", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(dictionary, new List<int> { 1 });
            LogAssert.Expect(LogType.Error, "Serialization Error: keys and values count mismatch.");
            Assert.DoesNotThrow(dictionary.OnAfterDeserialize);
            Assert.That(dictionary, Is.Empty);
        }

        [Test]
        public void DuoInt_PreservesMathematicsAndUnityConversions()
        {
            var pair = new DuoInt(2, 7);
            int2 mathValue = pair;
            Vector2Int unityValue = pair;
            Assert.That(mathValue, Is.EqualTo(new int2(2, 7)));
            Assert.That(unityValue, Is.EqualTo(new Vector2Int(2, 7)));
            Assert.That(((DuoInt)mathValue).secondValue, Is.EqualTo(7));
            Assert.That(pair.Clamp(10), Is.EqualTo(7));
        }

        [Test]
        public void ReflectionInjection_FindsInactiveSceneComponent()
        {
            var holder = new GameObject("Inactive reflection injection verification");
            holder.SetActive(false);
            try
            {
                var component = holder.AddComponent<InjectionProbe>();
                ReflectionUtils.InjectInstanceComponent<InjectionProbe>("marker", 7);
                Assert.That(component.Marker, Is.EqualTo(7));
            }
            finally { UnityEngine.Object.DestroyImmediate(holder); }
        }
        [Test]
        public void Toggle_PreservesOriginalUnlessEnabled()
        {
            var toggle = new IntToggle { enabled = false, newValue = 9 };
            Assert.That(toggle.Handle(3), Is.EqualTo(3));
            toggle.enabled = true;
            Assert.That(toggle.Handle(3), Is.EqualTo(9));
        }

        [Test]
        public void TaskCoroutine_WaitsAndPropagatesOriginalFailure()
        {
            var source = new TaskCompletionSource<bool>();
            var coroutine = source.Task.AsCoroutine();
            Assert.That(coroutine.MoveNext(), Is.True);
            var error = new InvalidOperationException("task regression");
            source.SetException(error);
            Assert.That(Assert.Throws<InvalidOperationException>(() => coroutine.MoveNext()), Is.SameAs(error));
        }

        [Test]
        public void TaskCoroutine_PropagatesCancellation()
        {
            var source = new TaskCompletionSource<bool>();
            source.SetCanceled();
            Assert.Throws<TaskCanceledException>(() => source.Task.AsCoroutine().MoveNext());
        }

        [Test]
        public void ExpandedDictionaryDrawer_ReservesSpaceForRowsAndAddButton()
        {
            var target = ScriptableObject.CreateInstance<DrawerProbe>();
            try
            {
                target.dictionary["one"] = 1;
                target.dictionary.OnBeforeSerialize();
                var serialized = new SerializedObject(target);
                var property = serialized.FindProperty("dictionary");
                property.isExpanded = true;
                var height = new SerializableDictionaryDrawer().GetPropertyHeight(property, GUIContent.none);
                Assert.That(height, Is.GreaterThanOrEqualTo(EditorGUIUtility.singleLineHeight * 3));
            }
            finally { UnityEngine.Object.DestroyImmediate(target); }
        }

        [UnityTest]
        public IEnumerator CollapsedDictionaryDrawer_PreservesIndentLevel()
        {
            var window = ScriptableObject.CreateInstance<DrawerProbeWindow>();
            window.Show();
            try
            {
                for (var frame = 0; frame < 120 && !window.Drawn; frame++)
                {
                    window.Repaint();
                    yield return null;
                }
                Assert.That(window.Drawn, Is.True, "Editor window did not receive a GUI event.");
                Assert.That(window.Error, Is.Null);
                Assert.That(window.IndentAfter, Is.EqualTo(3));
            }
            finally { window.Close(); }
        }
    }

    public sealed class InjectionProbe : MonoBehaviour
    {
#pragma warning disable CS0649
        private int marker;
#pragma warning restore CS0649
        public int Marker => marker;
    }

    public sealed class DrawerProbe : ScriptableObject
    {
        public SerializableDictionary<string, int> dictionary = new SerializableDictionary<string, int>();
    }

    public sealed class DrawerProbeWindow : EditorWindow
    {
        public bool Drawn;
        public int IndentAfter;
        public Exception Error;

        private void OnGUI()
        {
            if (Drawn) return;
            var target = ScriptableObject.CreateInstance<DrawerProbe>();
            var previous = EditorGUI.indentLevel;
            try
            {
                var serialized = new SerializedObject(target);
                var property = serialized.FindProperty("dictionary");
                property.isExpanded = false;
                EditorGUI.indentLevel = 3;
                new SerializableDictionaryDrawer().OnGUI(new Rect(0, 0, 400, 18), property, GUIContent.none);
                IndentAfter = EditorGUI.indentLevel;
            }
            catch (Exception error) { Error = error; }
            finally
            {
                EditorGUI.indentLevel = previous;
                UnityEngine.Object.DestroyImmediate(target);
                Drawn = true;
            }
        }
    }
}
