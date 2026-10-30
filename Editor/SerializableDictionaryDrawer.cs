using UnityEditor;
using UnityEngine;

namespace SWeetJelly
{
    [CustomPropertyDrawer(typeof(SerializableDictionary<,>), true)]
    public class SerializableDictionaryDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var height = EditorGUIUtility.singleLineHeight;
            if (!property.isExpanded)
                return height;

            var keys = property.FindPropertyRelative("keys");
            var values = property.FindPropertyRelative("values");
            if (keys.arraySize != values.arraySize)
                return height * 3 + EditorGUIUtility.standardVerticalSpacing;

            for (var i = 0; i < keys.arraySize; i++)
                height += RowHeight(keys, values, i) + EditorGUIUtility.standardVerticalSpacing;
            return height + EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var indent = EditorGUI.indentLevel;
            EditorGUI.BeginProperty(position, label, property);
            try
            {
                var line = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
                property.isExpanded = EditorGUI.Foldout(line, property.isExpanded, label);
                if (!property.isExpanded)
                    return;

                var keys = property.FindPropertyRelative("keys");
                var values = property.FindPropertyRelative("values");
                line.y += line.height + EditorGUIUtility.standardVerticalSpacing;
                if (keys.arraySize != values.arraySize)
                {
                    line.height = EditorGUIUtility.singleLineHeight * 2;
                    EditorGUI.HelpBox(line, "Serialized keys and values count mismatch.", MessageType.Error);
                    return;
                }

                EditorGUI.indentLevel = indent + 1;
                line = EditorGUI.IndentedRect(line);
                EditorGUI.indentLevel = 0;
                var halfWidth = (line.width - EditorGUIUtility.standardVerticalSpacing) / 2;
                for (var i = 0; i < keys.arraySize; i++)
                {
                    line.height = RowHeight(keys, values, i);
                    EditorGUI.PropertyField(new Rect(line.x, line.y, halfWidth, line.height),
                        keys.GetArrayElementAtIndex(i), GUIContent.none, true);
                    EditorGUI.PropertyField(new Rect(line.x + halfWidth + EditorGUIUtility.standardVerticalSpacing,
                        line.y, halfWidth, line.height), values.GetArrayElementAtIndex(i), GUIContent.none, true);
                    line.y += line.height + EditorGUIUtility.standardVerticalSpacing;
                }

                line.height = EditorGUIUtility.singleLineHeight;
                if (GUI.Button(line, "Add"))
                {
                    keys.arraySize++;
                    values.arraySize++;
                }
            }
            finally
            {
                EditorGUI.indentLevel = indent;
                EditorGUI.EndProperty();
            }
        }

        private static float RowHeight(SerializedProperty keys, SerializedProperty values, int index)
        {
            return Mathf.Max(EditorGUI.GetPropertyHeight(keys.GetArrayElementAtIndex(index), true),
                EditorGUI.GetPropertyHeight(values.GetArrayElementAtIndex(index), true));
        }
    }
}
