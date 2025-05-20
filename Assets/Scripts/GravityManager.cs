using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    /// <summary>
    /// The maximum distance at which an object's gravity affects a ship
    /// </summary>
    [SerializeField] private float GRAVITY_DIST_CUTOFF = 100.0f;  

    private List<Ship> _affectedByGravity;

    private static Vector2 CalcGravityVec(float objMass, Vector3 directionVec, float dist) {
        
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
        foreach (Ship s in _affectedByGravity){
            Vector2 gravityVec = new Vector2();
            // For every gravitational object
            foreach (CelestialObject co in celestialObjects)
            {
                // If this object is close enough to the ship to affect it 
                float dist = Vector3.Distance(s.transform.localPosition, co.transform.localPosition);
                if (dist < GRAVITY_DIST_CUTOFF)
                {
                    gravityVec += 
                }
            }
        }
    }
}
