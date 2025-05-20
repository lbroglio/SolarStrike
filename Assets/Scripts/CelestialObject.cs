using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObject : MonoBehaviour
{
    /// <summary>
    /// The strength of the gravitational pull of this object. 
    /// This element doesn't have any units and is given meaning by its relation 
    /// to the gravity stength of other objects. 
    /// </summary>
    [SerializeField] private float gravityStrength = 1.0f;

    /// <summary>
    /// The strength of the gravitational pull of this object. 
    /// This element doesn't have any units and is given meaning by its relation 
    /// to the gravity stength of other objects. 
    /// </summary>
    public float GravityStrength {
        get { return gravityStrength; }
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
