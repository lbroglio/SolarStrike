using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    // Static variables
    /// <summary>
    /// The fastest a ship can accelerate 
    /// </summary>
    readonly static private float MAX_ACCEL = 19.6f;

    /// <summary>
    /// How often in seconds the accleration can be updated
    /// </summary>
    readonly static private float ACCEL_UPDATES_INTERVAL = 0.3f;

    /// <summary>
    /// The maximum amount a ship can rotate in a second
    /// </summary> 
    readonly static private float MAX_ROT = 720f;



    /// <summary>
    /// The amount to accelerate by when the engine is on
    /// </summary>
    private float accelFromBurn = 4.9f;

    /// <summary>
    /// Last time (in seconds) the acceleration was updated
    /// </summary> 
    private float lastUpdateTime = 0;

    /// <summary>
    /// The number of degrees which have already been automatically rotated
    /// </summary>
    private float degreesAutoRotated = 0.0f;
    /// <summary>
    /// The number of degrees to be rotated automatically
    /// </summary>
    private float autoRotateAmount = 0.0f;

    /// <summary>
    /// The change in this Ship's position every second measured in units/s
    /// </summary>     
    private Vector3 _velocityVector;

    /// <summary>
    /// The change in this ships direction every second measured in degrees
    /// </summary> 
    private float _angularVelocity;

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
        _angularVelocity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Controls 

        // Increase angular velocity 
        if (Input.GetKey(KeyCode.E) && _angularVelocity >= -1 * MAX_ROT)
        {
  
             _angularVelocity -= MAX_ROT * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.Q) && _angularVelocity <= MAX_ROT)
        {
            _angularVelocity += MAX_ROT * Time.deltaTime;

        }

        // Rotate a fixed amount
        if (Input.GetKeyDown(KeyCode.D) && _angularVelocity == 0)
        {
            autoRotateAmount = -45f;
        }
        else if(Input.GetKeyDown(KeyCode.A) && _angularVelocity == 0)
        {
            autoRotateAmount = 45f;
        }


        // Slow rotation to a stop
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (_angularVelocity > 0)
            {
                _angularVelocity -= MAX_ROT * Time.deltaTime;

            }
            else if (_angularVelocity < 0)
            {
                _angularVelocity += MAX_ROT * Time.deltaTime;

            }

            if (MathF.Abs(_angularVelocity) < 0.01)
            {
                _angularVelocity = 0;
            }
        }

        // Increase burn strength if not at max
        if (Input.GetKey(KeyCode.W) && accelFromBurn < MAX_ACCEL)
        {


            // Go up to the next increment of 0.5g
            if (Input.GetKey(KeyCode.LeftShift) && Time.time - lastUpdateTime > ACCEL_UPDATES_INTERVAL)
            {
                int nextInc = Mathf.FloorToInt(accelFromBurn / Constants.HALF_G);
                nextInc += 1;

                accelFromBurn = Constants.HALF_G * nextInc;

            }

            if (Time.time - lastUpdateTime > ACCEL_UPDATES_INTERVAL)
            {
                // Increment fluidly 
                accelFromBurn += 0.5f;
                lastUpdateTime = Time.time;

            }

        }
        else if (Input.GetKey(KeyCode.S) && accelFromBurn > 0.0f)
        {

            // Go up to the next increment of 0.5g
            if (Input.GetKey(KeyCode.LeftShift) && Time.time - lastUpdateTime > ACCEL_UPDATES_INTERVAL)
            {
                int nextInc = Mathf.CeilToInt(accelFromBurn / Constants.HALF_G);
                nextInc -= 1;

                accelFromBurn = Constants.HALF_G * nextInc;

            }


            if (Time.time - lastUpdateTime > ACCEL_UPDATES_INTERVAL)
            {
                // Increment fluidly 
                accelFromBurn -= 0.5f;
                lastUpdateTime = Time.time;
            }
        }

        // Handle "autorotation"
        if (Mathf.Abs(autoRotateAmount) > 0)
        {

            // If in first 40% of rotation accelerate 
            if (Mathf.Abs(degreesAutoRotated / autoRotateAmount) <= 0.4f)
            {
                if (autoRotateAmount > 0)
                {
                    _angularVelocity += MAX_ROT * Time.deltaTime;
                }
                else
                {
                    _angularVelocity -= MAX_ROT * Time.deltaTime;
                }


            }

            // If in last 40% of rotation accelerate 
            if (Mathf.Abs(degreesAutoRotated / autoRotateAmount) >= 0.6f)
            {
                if (autoRotateAmount > 0)
                {
                    _angularVelocity -= MAX_ROT * Time.deltaTime;
                }
                else
                {
                    _angularVelocity += MAX_ROT * Time.deltaTime;
                }

            }

            degreesAutoRotated += _angularVelocity * Time.deltaTime;

            // If within the range to the target cut rotation and stop auto rotation
            if (Mathf.Abs(autoRotateAmount) - Math.Abs(degreesAutoRotated) < 1f)
            {
                _angularVelocity = 0;
                degreesAutoRotated = 0;
                autoRotateAmount = 0;
            }
        }

        // Fire main drive
        if (Input.GetKey(KeyCode.Space))
        {
            _velocityVector += transform.rotation * Vector3.up * accelFromBurn * Time.deltaTime;
        }


        // Update position 
        transform.position += _velocityVector * Time.deltaTime;

        // Update rotation
        transform.Rotate(new Vector3(0, 0, _angularVelocity * Time.deltaTime));
    }
}
