using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObject : MonoBehaviour
{
    /// <summary>
    /// The mass of Earth in Kilograms
    /// </summary> 
    readonly private static float MASS_OF_EARTH = 5972000000000000000000000f;

    /// <summary>
    /// The object that this CelestialObject orbits
    /// </summary>
    public CelestialObject parentObject = null;

    /// <summary>
    /// The mass of this object in number of Earth Masses it is.
    /// </summary>
    [SerializeField] private float earthMasses = 1.0f;

    /// <summary>
    /// The current amount in degrees this object has rotated around its parent
    /// </summary> 
    private float currentOrbitinDegrees = 0.0f;

    /// <summary>
    /// The mass of thie celestial object measured in kilograms
    /// </summary>
    public float Mass
    {
        get { return earthMasses * MASS_OF_EARTH; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (parentObject != null)
        {
            float orbitalVelocity = Utils.CalcOrbitalVelocity(parentObject.Mass,
                parentObject.transform.localPosition, transform.localPosition);

            float distToParent = Vector3.Distance(parentObject.transform.localPosition, transform.localPosition);
            float radiansPerSecond = orbitalVelocity / distToParent;

            float degreesPerSecond = radiansPerSecond * (180 / Mathf.PI);

            currentOrbitinDegrees += (degreesPerSecond * Time.deltaTime) * /*Arbitrary slowdown factor for gameplay sake*/ 0.1f;
            currentOrbitinDegrees %= 360;

            float newX = distToParent * Mathf.Cos(currentOrbitinDegrees);
            float newY = distToParent * Mathf.Sin(currentOrbitinDegrees);

            transform.localPosition = new Vector3(newX, newY, 0);
        }
    }
}
