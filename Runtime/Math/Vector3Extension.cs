
using UnityEngine;

namespace Mew.UnityUtils
{
    public static class Vector3Extension
    {
        public static Vector3 ToHorizontal(this Vector3 vector)
        {
            return new Vector3(vector.x, 0, vector.z);
        }

        public static Vector3 Slope(this Vector3 planeNormal, Vector3 up)
        {
            return Vector3.Cross(Vector3.Cross(up, planeNormal), planeNormal);
        }
    }
}