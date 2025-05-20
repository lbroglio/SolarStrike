using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class holding mathematical constants 
/// </summary>
public static class Constants
{
    /// <summary>
    /// The gravitational constant
    /// </summary>
    readonly static public float GRAVITATIONAL_CONSTANT = 6.67430e-11F;


    /// <summary>
    /// The number of meters in a single Unity unit (ie distance from x=1 to x=2).
    /// Based on setting one Earth diameter to 1 unit
    /// </summary>
    readonly static public float METERS_TO_UNITS = 12756200f;
}

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


    /// <summary>
    /// Calculate the speed needed to orbit a
    /// </summary>
    /// <returns></returns> 
    public static float CalcOrbitalVelocity(float objMass, Vector3 objPos, Vector3 shipPos)
    {
        float orbitalDistance = Vector3.Distance(objPos, shipPos) * Constants.METERS_TO_UNITS;
        return Mathf.Sqrt((Constants.GRAVITATIONAL_CONSTANT * objMass) / Mathf.Pow(orbitalDistance, 2));
    }
}


