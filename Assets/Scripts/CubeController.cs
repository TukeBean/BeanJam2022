using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public ForceMode forceMode = ForceMode.VelocityChange;
    Vector3 START_POSITION = new Vector3(6, 3, 0);
    public int torqueForce = 100;
    public float jumpForce = 4.5f;
    public float moveSpeed = 0.008f;
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
        GroundLayers = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        GroundedCheck();
        Move();
    }

    private void Move()
    {
        // JUMP
        if (Grounded && Input.GetKeyDown(KeyCode.Space)) 
        { 
            mRigidBody.AddForce(mRigidBody.velocity.normalized * jumpForce, forceMode);
        }

        // WASD MOVEMENT
        if (Input.GetKey(KeyCode.W)) 
        { 
            mRigidBody.AddTorque(torqueForce, torqueForce, 0,forceMode);
            mRigidBody.AddForce(Vector3.forward * moveSpeed, forceMode);
        }
        if (Input.GetKey(KeyCode.A)) 
        { 
            mRigidBody.AddTorque(0, torqueForce, torqueForce,forceMode);
            mRigidBody.AddForce(Vector3.left * moveSpeed, forceMode);
        }
        if (Input.GetKey(KeyCode.S)) 
        { 
            mRigidBody.AddTorque(-torqueForce, torqueForce, 0, forceMode);
            mRigidBody.AddForce(Vector3.back * moveSpeed, forceMode);
        }
        if (Input.GetKey(KeyCode.D)) 
        { 
            mRigidBody.AddTorque(0, torqueForce, -torqueForce, forceMode);
            mRigidBody.AddForce(Vector3.right * moveSpeed, forceMode);
        }

        //reset button
        if (Input.GetKey(KeyCode.R)) 
        { 
            mRigidBody.MovePosition(START_POSITION);
            //velocity needs set to zero or you'll keep your momentum
            mRigidBody.velocity = new Vector3(0,0,0);
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