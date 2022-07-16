using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    Rigidbody dice;

    void Start()
    {
        dice = GetComponent<Rigidbody>();
        dice.AddTorque(0, 0, -10, ForceMode.VelocityChange);

    }


    void Update()
    {
    
        dice.AddForceAtPosition(Vector3.right, dice.position, ForceMode.VelocityChange);
       //dice.AddForce(Vector3.right * 0.01f, ForceMode.VelocityChange);
    }

}
