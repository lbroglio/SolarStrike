using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    private List<Ship> _affectedByGravity;


    public void RegisterShip(Ship toRegister){
        _affectedByGravity.Add(toRegister);
    }

    void Awake(){
        _affectedByGravity = new List<Ship>();
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
