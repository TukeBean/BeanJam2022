using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public ForceMode forceMode = ForceMode.VelocityChange;
    Vector3 START_POSITION = new Vector3(0, 0, 0);
    public int torqueForce = 100;
    public float jumpForce = 4.5f;
    public float moveSpeed = 0.008f;
    public float chungus = 2f;
    public CollectablesManager colManager;
    public GameObject endScreen;

    public GameObject onscreenText1;
    public GameObject onscreenText2;

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
        START_POSITION = transform.position;
        mRigidBody = GetComponent<Rigidbody>();
        GroundLayers = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        GroundedCheck();
        Move();
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag=="deathCube"){
            resetPos();
        }
        if(collider.gameObject.tag=="checkpoint"){
            string checkpointName = collider.gameObject.name;
            updatePos(checkpointName);
        }
        if(collider.gameObject.tag=="endpoint"){
            endGame();
        }
    }

    void endGame(){
        // activate attached gameObject
        endScreen.SetActive(true); 
        onscreenText1.SetActive(false);
        onscreenText2.SetActive(false);
    }
    private void Move()
    {

        // JUMP
        if (Grounded && Input.GetKeyDown(KeyCode.Space))
        {

            if (mRigidBody.velocity.magnitude < 5)
            {
                mRigidBody.AddForce(new Vector3(0f, chungus, 0f) + (mRigidBody.velocity * jumpForce), forceMode);
            }
            else
            {
                mRigidBody.AddForce((mRigidBody.velocity.normalized * jumpForce), forceMode);
            }
        }

        // WASD MOVEMENT
        if (Input.GetKey(KeyCode.W))
        {
            mRigidBody.AddTorque(torqueForce, torqueForce, 0, forceMode);
            mRigidBody.AddForce(Vector3.forward * moveSpeed, forceMode);
        }
        if (Input.GetKey(KeyCode.A))
        {
            mRigidBody.AddTorque(0, torqueForce, torqueForce, forceMode);
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
            resetPos();
        }
    }

    void resetPos(){
        mRigidBody.MovePosition(START_POSITION);
        //velocity needs set to zero or you'll keep your momentum
        mRigidBody.velocity = new Vector3(0, 0, 0);
        colManager.resetCollectables();
    }

    // when the checkpoint is hit
    void updatePos(string checkpointName){

         START_POSITION = transform.position;
         colManager.NextCheckpoint(int.Parse(checkpointName));
    }

    void GroundedCheck()
    {
        Vector3 dicePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
                transform.position.z);
        Vector3 diceScale = transform.localScale / 2;
        Quaternion diceRotation = transform.rotation;

        Grounded = Physics.CheckBox(dicePosition, diceScale, diceRotation, GroundLayers);
    }
}