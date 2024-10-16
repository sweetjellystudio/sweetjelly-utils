using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SWeetJelly
{
    public static class Bezier
    {
        /// <summary>
        /// Evaluates a quadratic Bezier curve at a given time value.
        /// </summary>
        /// <param name="a">The starting point of the curve.</param>
        /// <param name="b">The control point of the curve.</param>
        /// <param name="c">The ending point of the curve.</param>
        /// <param name="t">The time value (between 0 and 1) at which to evaluate the curve.</param>
        /// <returns>The point on the curve at the given time value.</returns>
        public static Vector3 EvaluateQuadratic(Vector3 a, Vector3 b, Vector3 c, float t)
        {
            Vector3 p0 = Vector3.Lerp(a, b, t);
            Vector3 p1 = Vector3.Lerp(b, c, t);
            return Vector3.Lerp(p0, p1, t);
        }

        /// <summary>
        /// Evaluates a cubic Bezier curve at a given time value.
        /// </summary>
        /// <param name="a">The starting point of the curve.</param>
        /// <param name="b">The first control point of the curve.</param>
        /// <param name="c">The second control point of the curve.</param>
        /// <param name="d">The ending point of the curve.</param>
        /// <param name="t">The time value (between 0 and 1) at which to evaluate the curve.</param>
        /// <returns>The point on the curve at the given time value.</returns>
        public static Vector3 EvaluateCubic(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
        {
            Vector3 p0 = EvaluateQuadratic(a, b, c, t);
            Vector3 p1 = EvaluateQuadratic(b, c, d, t);
            return Vector3.Lerp(p0, p1, t);
        }

        /// <summary>
        /// Approximates the length of a cubic Bezier curve defined by four points.
        /// </summary>
        /// <param name="points">An array of four points defining the curve.</param>
        /// <returns>The approximate length of the curve.</returns>
        public static float AproximateLength(Vector3[] points)
        {
            return AproximateLength(points[0], points[1], points[2], points[3]);
        }

        /// <summary>
        /// Approximates the length of a cubic Bezier curve defined by four points.
        /// </summary>
        /// <param name="p0">The starting point of the curve.</param>
        /// <param name="p1">The first control point of the curve.</param>
        /// <param name="p2">The second control point of the curve.</param>
        /// <param name="p3">The ending point of the curve.</param>
        /// <returns>The approximate length of the curve.</returns>
        public static float AproximateLength(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            float chord = (p3 - p0).magnitude;
            float cont_net = (p1 - p0).magnitude + (p2 - p1).magnitude + (p3 - p2).magnitude;

            return (cont_net + chord) / 2;
        }
    }
}