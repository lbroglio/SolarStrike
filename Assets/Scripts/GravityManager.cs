using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{

    /// <summary>
    /// The maximum distance at which an object's gravity affects a ship
    /// </summary>
    // TODO: This should scale with planet size
    [SerializeField] private float GRAVITY_DIST_CUTOFF = 100.0f;


    private List<Ship> _affectedByGravity;

    private Vector3 CalcGravityVec(float objMass, Vector3 directionVec, float dist) {
        dist *= Constants.UNITS_TO_METERS;
        float accelFromGravity = Constants.GRAVITATIONAL_CONSTANT * objMass / Mathf.Pow(dist, 2);
        // Convert from m/s^2 to units/s^2
        return accelFromGravity * directionVec;
    }

    /// <summary>
    /// Add a Ship object to be influenced by gravity 
    /// </summary>
    /// <param name="toRegister">The ship which wants to be influenced by gravity</param>
    public void RegisterShip(Ship toRegister) {
        _affectedByGravity.Add(toRegister);
    }

    void Awake(){
        _affectedByGravity = new List<Ship>();
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        // Get all objects with gravity 
        CelestialObject[] celestialObjects = FindObjectsOfType<CelestialObject>();

        // For every ship
        foreach (Ship s in _affectedByGravity)
        {
            // Vector totaling all gravity influence
            Vector3 gravityVec = new Vector2();
            // For every gravitational object
            foreach (CelestialObject co in celestialObjects)
            {
                // If this object is close enough to the ship to affect it 
                float dist = Vector3.Distance(s.transform.localPosition, co.transform.localPosition);
                if (dist < GRAVITY_DIST_CUTOFF)
                {
                    Vector3 direcVec = Utils.GetFromToVector(co.transform, s.transform);
                    gravityVec += CalcGravityVec(co.Mass, direcVec, dist);
                }
            }

            // Change the ship's velocity by the gravity
            s.VelocityVector += gravityVec * Time.deltaTime;
        }
    }
}
