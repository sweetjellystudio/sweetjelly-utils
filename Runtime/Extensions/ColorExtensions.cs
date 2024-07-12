using UnityEngine;
using UnityEngine.UI;

namespace SWeetJelly
{
    public static class ColorExtensions
    {
        #region Color
        /// <summary>
        /// Set color alpha
        /// </summary>
        public static Color SetAlpha(this Color color, byte aValue)
        {
            color.a = aValue;

            return color;
        }

        /// <summary>
        /// Set color alpha
        /// </summary>
        public static Graphic SetAlpha(this Graphic graphic, float a)
        {
            graphic.color = graphic.color.SetAlpha(a);

            return graphic;
        }

        /// <summary>
        /// Set color alpha
        /// </summary>
        public static Color SetAlpha(this Color color, float aValue)
        {
            color.a = aValue;

            return color;
        }

        /// <summary>
        /// Set color alpha (0-255)
        /// </summary>
        public static Color SetAlpha(this Color color, int aValue)
        {
            color.a = (float)aValue / 255;

            return color;
        }

        /// <summary>
        /// Convert to HEX
        /// </summary>
        public static string ToHex(this Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", (byte)(Mathf.Clamp01(color.r) * 255), (byte)(Mathf.Clamp01(color.g) * 255), (byte)(Mathf.Clamp01(color.b) * 255));
        }
        #endregion


    }
}