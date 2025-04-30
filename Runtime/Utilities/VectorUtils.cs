using UnityEngine;

namespace SWeetJelly
{
    public static class VectorUtils
    {
        /// <summary>
        /// Calculate the angle between two vectors in degrees.(0 ~ 360)
        /// </summary>
        /// <param name="vector1">The first vector.</param>
        /// <param name="vector2">The second vector.</param>
        /// <returns>The angle between the two vectors in degrees.</returns>
        public static float AngleBetween(Vector2 vector1, Vector2 vector2)
        {
            float angle = Vector2.Angle(vector1, vector2);
            Vector3 cross = Vector3.Cross(vector1, vector2);

            if(cross.z > 0)
            {
                angle = 360 - angle;
            }

            return angle;
        }
    }
}