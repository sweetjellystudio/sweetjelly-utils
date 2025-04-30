using UnityEngine;

namespace SWeetJelly
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Sets any x y z values of a Vector3
        /// </summary>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null) {
            return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
        }

        /// <summary>
        /// Adds to any x y z values of a Vector3
        /// </summary>
        public static Vector3 Add(this Vector3 vector, float x = 0, float y = 0, float z = 0) {
            return new Vector3(vector.x + x, vector.y + y, vector.z + z);
        }

        /// <summary>
        /// Returns a Boolean indicating whether the current Vector3 is in a given range from another Vector3
        /// </summary>
        /// <param name="current">The current Vector3 position</param>
        /// <param name="target">The Vector3 position to compare against</param>
        /// <param name="range">The range value to compare against</param>
        /// <returns>True if the current Vector3 is in the given range from the target Vector3, false otherwise</returns>
        public static bool InRangeOf(this Vector3 current, Vector3 target, float range) {
            return (current - target).sqrMagnitude <= range * range;
        }
        
        /// <summary>
        /// Divides two Vector3 objects component-wise.
        /// </summary>
        /// <remarks>
        /// For each component in v0 (x, y, z), it is divided by the corresponding component in v1 if the component in v1 is not zero. 
        /// Otherwise, the component in v0 remains unchanged.
        /// </remarks>
        /// <example>
        /// Use 'ComponentDivide' to scale a game object proportionally:
        /// <code>
        /// myObject.transform.localScale = originalScale.ComponentDivide(targetDimensions);
        /// </code>
        /// This scales the object size to fit within the target dimensions while maintaining its original proportions.
        ///</example>
        /// <param name="v0">The Vector3 object that this method extends.</param>
        /// <param name="v1">The Vector3 object by which v0 is divided.</param>
        /// <returns>A new Vector3 object resulting from the component-wise division.</returns>
        public static Vector3 ComponentDivide(this Vector3 v0, Vector3 v1){
            return new Vector3( 
                v1.x != 0 ? v0.x / v1.x : v0.x, 
                v1.y != 0 ? v0.y / v1.y : v0.y, 
                v1.z != 0 ? v0.z / v1.z : v0.z);  
        }
        
        /// <summary>
        /// Computes a random point in an annulus (a ring-shaped area) based on minimum and 
        /// maximum radius values around a central Vector3 point (origin).
        /// </summary>
        /// <param name="origin">The center Vector3 point of the annulus.</param>
        /// <param name="minRadius">Minimum radius of the annulus.</param>
        /// <param name="maxRadius">Maximum radius of the annulus.</param>
        /// <returns>A random Vector3 point within the specified annulus.</returns>
        public static Vector3 RandomPointInAnnulus(this Vector3 origin, float minRadius, float maxRadius) {
            float angle = Random.value * Mathf.PI * 2f;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    
            // Squaring and then square-rooting radii to ensure uniform distribution within the annulus
            float minRadiusSquared = minRadius * minRadius;
            float maxRadiusSquared = maxRadius * maxRadius;
            float distance = Mathf.Sqrt(Random.value * (maxRadiusSquared - minRadiusSquared) + minRadiusSquared);
    
            // Converting the 2D direction vector to a 3D position vector
            Vector3 position = new Vector3(direction.x, 0, direction.y) * distance;
            return origin + position;
        }

        /// <summary>
        ///  Adds to each component specified value
        /// </summary>
        /// <param name="floatValue">value to add</param>
        /// <returns></returns>
        public static Vector3 AddFloat(this Vector3 vector, float floatValue)
        {
            vector.x += floatValue;
            vector.y += floatValue;
            vector.z += floatValue;

            return vector;
        }

        /// <summary>
        /// Adds to x component specified value
        /// </summary>
        /// <param name="value">value to add</param>
        /// <returns></returns>
        public static Vector3 AddToX(this Vector3 vector, float value)
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
        public static Vector3 AddToY(this Vector3 vector, float value)
        {
            vector.y += value;

            return vector;
        }

        /// <summary>
        /// Adds to z component specified value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value">value to add</param>
        /// <returns></returns>
        public static Vector3 AddToZ(this Vector3 vector, float value)
        {
            vector.z += value;

            return vector;
        }

        /// <summary>
        /// Multiplies x component to specified value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value">value to multiply</param>
        /// <returns></returns>
        public static Vector3 MultX(this Vector3 vector, float value)
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
        public static Vector3 MultY(this Vector3 vector, float value)
        {
            vector.y *= value;

            return vector;
        }

        /// <summary>
        /// Multiplies z component to specified value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value">value to multiply</param>
        /// <returns></returns>
        public static Vector3 MultZ(this Vector3 vector, float value)
        {
            vector.z *= value;

            return vector;
        }

        /// <summary>
        /// Sets to x component specified value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value">value to set</param>
        /// <returns></returns>
        public static Vector3 SetX(this Vector3 vector, float value)
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
        public static Vector3 SetY(this Vector3 vector, float value)
        {
            vector.y = value;

            return vector;
        }

        /// <summary>
        /// Sets to z component specified value
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value">value to set</param>
        /// <returns></returns>
        public static Vector3 SetZ(this Vector3 vector, float value)
        {
            vector.z = value;

            return vector;
        }

        /// <summary>
        /// Sets x,y,z specified value
        /// </summary>
        /// <param name="valueOfXYZ">value to set</param>
        /// <returns></returns>
        public static Vector3 SetAll(this Vector3 vector, float valueOfXYZ)
        {
            vector.x = valueOfXYZ;
            vector.y = valueOfXYZ;
            vector.z = valueOfXYZ;

            return vector;
        }

        /// <summary>
        /// Convert float value to Vector3
        /// </summary>
        /// <param name="value">value to convert</param>
        /// <returns></returns>
        public static Vector3 ToVector3(this float value)
        {
            return new Vector3(value, value, value);
        }

        /// <summary>
        /// Convert int value to Vector3
        /// </summary>
        /// <param name="value">value to convert</param>
        /// <returns></returns>
        public static Vector3 ToVector3(this int value)
        {
            return new Vector3(value, value, value);
        }

        /// <summary>
        /// Convert to World position
        /// </summary>
        public static Vector3 ToWorldPosition(this Vector3 vector, float z = 0)
        {
            vector.z = z;
            return Camera.main.ScreenToWorldPoint(vector);
        }

        /// <summary>
        /// Get random position x,z position around position
        /// </summary>
        public static Vector3 GetRandomPositionAroundObject(this Vector3 position, float minRadius, float maxRadius)
        {
            float radius = Random.Range(minRadius, maxRadius);

            float angle = Random.Range(0, 360);

            float x = radius * Mathf.Cos(angle);
            float z = radius * Mathf.Sin(angle);

            return new Vector3(position.x + x, position.y, position.z + z);
        }

        /// <summary>
        /// Get random position x,z position around position
        /// </summary>
        public static Vector3 GetRandomPositionAroundObject(this Vector3 position, float radius)
        {
            float angle = Random.Range(0, 360);

            float x = radius * Mathf.Cos(angle);
            float z = radius * Mathf.Sin(angle);

            return new Vector3(position.x + x, position.y, position.z + z);
        }

        public static Vector3 GetRandomPosition(this Bounds bounds)
        {
            var halfWidth = bounds.size.x / 2f;
            var halfHeight = bounds.size.y / 2f;
            var halfDepth = bounds.size.z / 2f;

            var result = bounds.center + new Vector3(
                Random.Range(-halfWidth, halfWidth),
                Random.Range(-halfHeight, halfHeight),
                Random.Range(-halfDepth, halfDepth));

            return result;
        }

        public static Vector3 Rotate(this Vector3 vector, float degree, Vector3 axis)
        {
            return Quaternion.AngleAxis(degree, axis) * vector;
        }

        public static Vector2 xz(this Vector3 value) => new Vector2(value.x, value.z);
        public static Vector2 xy(this Vector3 value) => new Vector2(value.x, value.y);

        public static Vector3 xyz(this Vector4 value) => new Vector3(value.x, value.y, value.z);
        public static Vector2 xy(this Vector4 value) => new Vector2(value.x, value.y);
    }
}