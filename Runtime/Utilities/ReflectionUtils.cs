using System.Reflection;
using UnityEngine;

namespace SWeetJelly
{
    public static class ReflectionUtils
    {
        public static readonly BindingFlags FLAGS_INSTANCE_PRIVATE = BindingFlags.Instance | BindingFlags.NonPublic;
        public static readonly BindingFlags FLAGS_INSTANCE_PUBLIC = BindingFlags.Instance | BindingFlags.Public;

        public static readonly BindingFlags FLAGS_STATIC_PRIVATE = BindingFlags.Static | BindingFlags.NonPublic;
        public static readonly BindingFlags FLAGS_STATIC_PUBLIC = BindingFlags.Static | BindingFlags.Public;

        public static void InjectInstanceComponent<T>(T instanceObject, string variableName, object value, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance)
        {
            instanceObject?.GetType().GetField(variableName, bindingFlags).SetValue(instanceObject, value);
        }

        public static void InjectInstanceComponent<T>(string variableName, object value, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance) where T : Object
        {
            T component = Object.FindObjectOfType<T>(true);
            component?.GetType().GetField(variableName, bindingFlags).SetValue(component, value);
        }

        public static void InjectStaticComponent<T>(string variableName, object value, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static) where T : Object
        {
            typeof(T).GetField(variableName, bindingFlags).SetValue(null, value);
        }

        public static object GetInstanceComponent<T>(T instanceObject, string variableName, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance)
        {
            return instanceObject?.GetType().GetField(variableName, bindingFlags).GetValue(instanceObject);
        }

        public static object GetStaticComponent<T>(string variableName, BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static) where T : Object
        {
            return typeof(T).GetField(variableName, bindingFlags).GetValue(null);
        }
    }
}