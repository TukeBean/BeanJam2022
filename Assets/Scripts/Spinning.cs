using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    public float spinSpeed = 1f;
    public Vector3 Rotaters;
    public float forceApplied = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Spin();
    }

    void Spin()
    {
        Rotaters = new Vector3(spinSpeed, 0f, 0f);
        transform.Rotate(Rotaters);
    }

    // Applies an upwards force to all rigidbodies that enter the trigger.
    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
            other.attachedRigidbody.AddForce(other.attachedRigidbody.velocity.normalized * forceApplied, ForceMode.VelocityChange);
    }
}
