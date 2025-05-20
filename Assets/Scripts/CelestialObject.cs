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
    /// The mass of this object in number of Earth Masses it is.
    [SerializeField] private float earthMasses = 1.0f;

    /// <summary>
    /// The mass of thie celestial object measured in kilograms
    /// </summary>
    public float Mass {
        get { return earthMasses * MASS_OF_EARTH; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
