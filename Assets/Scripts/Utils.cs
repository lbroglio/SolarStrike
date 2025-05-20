using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    /// <summary>
    /// Get a unit vector which leads from one unity object to another
    /// </summary>
    /// <param name="from">The transform of the GameObject the Vector should point from</param>
    /// <param name="to"The transform of the GameObject the Vector should point to></param>
    /// <returns>Unit vector which leads from one unity object to another</returns>
    public static Vector3 GetFromToVector(Transform from, Transform to)
    {
        Vector3 pointedVec = from.localPosition - to.localPosition;
        pointedVec.Normalize();
        return pointedVec;
    }
}
