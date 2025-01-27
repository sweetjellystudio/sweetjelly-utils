using UnityEditor;
using UnityEngine;

namespace SWeetJelly
{
    [CustomPropertyDrawer(typeof(SerializableDictionary<,>), true)]
    public class SerializableDictionaryDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty keys = property.FindPropertyRelative("keys");
            SerializedProperty values = property.FindPropertyRelative("values");

            Rect foldoutRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, label);

            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;
                for (int i = 0; i < keys.arraySize; i++)
                {
                    Rect keyRect = new Rect(position.x, position.y + (i + 1) * EditorGUIUtility.singleLineHeight, position.width / 2, EditorGUIUtility.singleLineHeight);
                    Rect valueRect = new Rect(position.x + position.width / 2, position.y + (i + 1) * EditorGUIUtility.singleLineHeight, position.width / 2, EditorGUIUtility.singleLineHeight);

                    EditorGUI.PropertyField(keyRect, keys.GetArrayElementAtIndex(i), GUIContent.none);
                    EditorGUI.PropertyField(valueRect, values.GetArrayElementAtIndex(i), GUIContent.none);
                }

                if (GUI.Button(new Rect(position.x, position.y + (keys.arraySize + 1) * EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight), "Add"))
                {
                    keys.arraySize++;
                    values.arraySize++;
                }
            }

            EditorGUI.indentLevel--;
            EditorGUI.EndProperty();
        }
    }
}