using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public int torqueLit = 100;
    Rigidbody mRigidBody;

    [Header("Player Grounded")]
    [Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
    public bool Grounded = true;
    [Tooltip("Useful for rough ground")]
    public float GroundedOffset = 0.15f;

    [Tooltip("What layers the character uses as ground")]
    public LayerMask GroundLayers;

    // Start is called before the first frame update
    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundedCheck();
        Move();
    }

    private void Move()
    {
        if (Grounded && Input.GetKey(KeyCode.Space)) 
        { 
            mRigidBody.velocity = new Vector3(0, 5, 5);
        }
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

    void GroundedCheck(){
        Vector3 dicePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
                transform.position.z);
        Vector3 diceScale = transform.localScale/2;
        Quaternion diceRotation = transform.rotation;

        Grounded = Physics.CheckBox(dicePosition, diceScale, diceRotation, GroundLayers);
    }
}