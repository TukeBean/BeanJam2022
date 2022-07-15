using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public int torqueLit = 100;
    Rigidbody mRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W)) 
        { 
            mRigidBody.AddTorque(torqueLit, 100, 0);
            
        }
        if (Input.GetKey(KeyCode.A)) 
        { 
            mRigidBody.AddTorque(0, 100, torqueLit);
        }
        if (Input.GetKey(KeyCode.S)) 
        { 
            mRigidBody.AddTorque(-torqueLit, 100, 0);
        }
        if (Input.GetKey(KeyCode.D)) 
        { 
            mRigidBody.AddTorque(0, 100, -torqueLit);
        }
    }
}