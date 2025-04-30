using UnityEngine;

namespace SWeetJelly
{
    public static class Vector2Extensions
    {
        public static float AngleBetween(this Vector2 vector1, Vector2 vector2)
        {
            float angle = Vector2.Angle(vector1, vector2);
            Vector3 cross = Vector3.Cross(vector1, vector2);

            if(cross.z > 0)
            {
                angle = 360 - angle;
            }

            return angle;
        }

        /// <summary>
        /// Adds to any x y values of a Vector2
        /// </summary>
        public static Vector2 Add(this Vector2 vector2, float x = 0, float y = 0) {
            return new Vector2(vector2.x + x, vector2.y + y);
        }

        /// <summary>
        /// Sets any x y values of a Vector2
        /// </summary>
        public static Vector2 With(this Vector2 vector2, float? x = null, float? y = null) {
            return new Vector2(x ?? vector2.x, y ?? vector2.y);
        }

        /// <summary>
        /// Returns a Boolean indicating whether the current Vector2 is in a given range from another Vector2
        /// </summary>
        /// <param name="current">The current Vector2 position</param>
        /// <param name="target">The Vector2 position to compare against</param>
        /// <param name="range">The range value to compare against</param>
        /// <returns>True if the current Vector2 is in the given range from the target Vector2, false otherwise</returns>
        public static bool InRangeOf(this Vector2 current, Vector2 target, float range) {
            return (current - target).sqrMagnitude <= range * range;
        }
        
        /// <summary>
        /// Computes a random point in an annulus (a ring-shaped area) based on minimum and 
        /// maximum radius values around a central Vector2 point (origin).
        /// </summary>
        /// <param name="origin">The center Vector2 point of the annulus.</param>
        /// <param name="minRadius">Minimum radius of the annulus.</param>
        /// <param name="maxRadius">Maximum radius of the annulus.</param>
        /// <returns>A random Vector2 point within the specified annulus.</returns>
        public static Vector2 RandomPointInAnnulus(this Vector2 origin, float minRadius, float maxRadius) {
            float angle = Random.value * Mathf.PI * 2f;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    
            // Squaring and then square-rooting radii to ensure uniform distribution within the annulus
            float minRadiusSquared = minRadius * minRadius;
            float maxRadiusSquared = maxRadius * maxRadius;
            float distance = Mathf.Sqrt(Random.value * (maxRadiusSquared - minRadiusSquared) + minRadiusSquared);
    
            // Calculate the position vector
            Vector2 position = direction * distance;
            return origin + position;
        }

        #region Vector2
        /// <summary>
        ///  Adds to each component specified value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="floatValue">value to add</param>
        /// <returns></returns>
        public static Vector2 AddFloat(this Vector2 vector, float floatValue)
        {
            vector.x += floatValue;
            vector.y += floatValue;

            return vector;
        }

        /// <summary>
        /// Adds to x component specified value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value">value to add</param>
        /// <returns></returns>
        public static Vector2 AddToX(this Vector2 vector, float value)
        {
            vector.x += value;

            return vector;
        }

        /// <summary>
        /// Adds to y component specified value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value">value to add</param>
        /// <returns></returns>
        public static Vector2 AddToY(this Vector2 vector, float value)
        {
            vector.y += value;

            return vector;
        }

        /// <summary>
        /// Multiplies x component to specified value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value">value to multiply</param>
        /// <returns></returns>
        public static Vector2 MultX(this Vector2 vector, float value)
        {
            vector.x *= value;

            return vector;
        }

        /// <summary>
        /// Multiplies y component to specified value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value">value to multiply</param>
        /// <returns></returns>
        public static Vector2 MultY(this Vector2 vector, float value)
        {
            vector.y *= value;

            return vector;
        }

        /// <summary>
        /// Sets to x component specified value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value">value to set</param>
        /// <returns></returns>
        public static Vector2 SetX(this Vector2 vector, float value)
        {
            vector.x = value;

            return vector;
        }

        /// <summary>
        /// Sets to y component specified value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value">value to set</param>
        /// <returns></returns>
        public static Vector2 SetY(this Vector2 vector, float value)
        {
            vector.y = value;

            return vector;
        }

        /// <summary>
        /// Convert float value to Vector2
        /// </summary>
        /// <param name="value">value to convert</param>
        /// <returns></returns>
        public static Vector2 ToVector2(this float value)
        {
            return new Vector2(value, value);
        }

        /// <summary>
        /// Convert int value to Vector2
        /// </summary>
        /// <param name="value">value to convert</param>
        public static Vector2 ToVector2(this int value)
        {
            return new Vector2(value, value);
        }

        /// <summary>
        /// Convert Vector2 to Vector3 with a z value.
        /// </summary>
        /// <param name="vector">The Vector2 to convert.</param>
        /// <param name="z">Z value</param>
        /// <returns>A Vector3 with the x and y values of the Vector2 and a z value.</returns>
        public static Vector3 ToVector3WithZ(this Vector2 vector, float z = 0)
        {
            return new Vector3(vector.x, vector.y, z);
        }

        /// <summary>
        /// Converts a Vector2 to a Vector3 with a y value.
        /// </summary>
        /// <param name="vector">The Vector2 to convert.</param>
        /// <param name="y">Y value</param>
        /// <returns>A Vector3 with the x and z values of the Vector2 and a y value.</returns>
        public static Vector3 ToVector3WithY(this Vector2 vector, float y = 0) {
            return new Vector3(vector.x, y, vector.y);
        }

        /// <summary>
        /// Converts a Vector2 to a Vector3 with a x value.
        /// </summary>
        /// <param name="vector">The Vector2 to convert.</param>
        /// <param name="x">X value</param>
        /// <returns>A Vector3 with the y and z values of the Vector2 and a x value.</returns>
        public static Vector3 ToVector3WithX(this Vector2 vector, float x = 0)
        {
            return new Vector3(x, vector.x, vector.y);
        }
        #endregion

    }
}