using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public int torqueLit = 100;
    public float mSpeed = 2f;
    Vector3 myVectorForward;
    Vector3 myVectorBackward;
    Vector3 myVectorLeft;
    Vector3 myVectorRight;
    
    Rigidbody mRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        myVectorForward = new Vector3(0.0f, 0.0f, 1.0f);
        myVectorBackward = new Vector3(0.0f, 0.0f, -1.0f);
        myVectorLeft = new Vector3(0.0f, 0.0f, 0.0f);
        myVectorRight = new Vector3(0.0f, 0.0f, 0.0f);
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
            mRigidBody.velocity = myVectorForward * mSpeed;
        }
        if (Input.GetKey(KeyCode.A)) 
        { 
            mRigidBody.AddTorque(0, 100, torqueLit);
            mRigidBody.velocity = myVectorLeft * mSpeed;
        }
        if (Input.GetKey(KeyCode.S)) 
        { 
            mRigidBody.AddTorque(-torqueLit, 100, 0);
            mRigidBody.velocity = myVectorBackward * mSpeed;
        }
        if (Input.GetKey(KeyCode.D)) 
        { 
            mRigidBody.AddTorque(0, 100, -torqueLit);
            mRigidBody.velocity = myVectorRight * mSpeed;
        }
    }
}