using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace SWeetJelly
{
    public static class CoreExtensions
    {
        #region Int
        /// <summary>
        /// Set random sign
        /// </summary>
        public static int SetRandomSign(this int value)
        {
            return value * Random.value < 0.5f ? 1 : -1;
        }
        #endregion

        #region Float
        /// <summary>
        /// Set random sign
        /// </summary>
        public static float SetRandomSign(this float value)
        {
            return value * Random.value < 0.5f ? 1 : -1;
        }
        #endregion

        #region Double
        /// <summary>
        /// Set random sign
        /// </summary>
        public static double SetRandomSign(this double value)
        {
            return value * Random.value < 0.5f ? 1 : -1;
        }
        #endregion

        #region RectTransform
        #endregion

        #region Quaternion
        #endregion

        #region Object
        private static readonly BindingFlags PUBLIC_BINDING_FLAGS = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        private static readonly string FIELD_SPACE = "    ";
        private static readonly int MAX_DEPTH = 3;

        public static string ObjectToString(this object parentObject)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<b>" + parentObject.ToString() + "</b>");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("Variables:");
            stringBuilder.Append(GetFields(0, "  ", parentObject));

            return stringBuilder.ToString();
        }

        private static string GetFields(int depth, string space, object parentObject)
        {
            depth += 1;
               
            StringBuilder stringBuilder = new StringBuilder();
            Type parentObjectType = parentObject.GetType();

            FieldInfo[] fieldInfos = parentObjectType.GetFields(PUBLIC_BINDING_FLAGS);

            string fieldName;
            object value;

            for (int i = 0; i < fieldInfos.Length; i++)
            {
                Type fieldType = fieldInfos[i].FieldType;

                fieldName = fieldInfos[i].Name;
                value = fieldInfos[i].GetValue(parentObject);

                if (fieldType.IsClass && fieldType != typeof(string))
                {
                    if (fieldType.IsArray)
                    {
                        Type elementType = fieldType.GetElementType();
                        if (elementType != null)
                        {
                            FieldInfo[] arrayFieldInfos = elementType.GetFields(PUBLIC_BINDING_FLAGS);

                            IList list = (IList)value;
                            if(list != null)
                            {
                                int listCount = list.Count;
                                for (int j = 0; j < listCount; j++)
                                {
                                    stringBuilder.AppendLine(space + "Element " + (j + 1));
                                    for (int f = 0; f < arrayFieldInfos.Length; f++)
                                    {
                                        object arrayValue = arrayFieldInfos[f].GetValue(list[j]);

                                        stringBuilder.AppendLine(space + "    " + arrayFieldInfos[f].Name + " - " + (arrayValue != null ? arrayValue.ToString() : "NULL"));
                                    }
                                }
                            }
                            else
                            {
                                stringBuilder.AppendLine(space + fieldName + " - NULL");
                            }
                        }
                    }
                    else
                    {
                        if (value != null)
                        {
                            stringBuilder.AppendLine(space + fieldName + " - " + fieldType.ToString());

                            if (depth < MAX_DEPTH)
                                stringBuilder.Append(GetFields(depth, space + FIELD_SPACE, value));
                        }
                        else
                        {
                            stringBuilder.AppendLine(space + fieldName + " - NULL");
                        }
                    }
                }
                else
                {
                    stringBuilder.AppendLine(space + fieldName + " - " + (value != null ? value.ToString() : "NULL"));
                }
            }

            return stringBuilder.ToString();
        }
        #endregion

        #region Random

        public static class ExtendedRandom
        {
            public static bool TrueFalse()
            {
                return Random.Range(0, 2) == 0;
            }

            public static int Range(DuoInt duoInt)
            {
                return Random.Range(duoInt.firstValue, duoInt.secondValue);
            }

            public static float Range(DuoFloat duoFloat)
            {
                return Random.Range(duoFloat.firstValue, duoFloat.secondValue);
            }
        }

        #endregion
    }
}