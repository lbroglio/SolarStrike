using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    /// <summary>
    /// The change in this Ship's position every second measured in units/s
    /// </summary>     
    private Vector3 _velocityVector;

    /// <summary>
    /// The change in this Ship's position every second
    /// </summary>     
    public Vector3 VelocityVector
    {
        get { return _velocityVector; }
        set { _velocityVector = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject gm = GameObject.Find("GameManager");
        gm.GetComponent<GravityManager>().RegisterShip(this);
        _velocityVector = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {



        // Update position 
        transform.position += _velocityVector * Time.deltaTime;
    }
}
