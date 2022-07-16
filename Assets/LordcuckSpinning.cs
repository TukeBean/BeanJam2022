using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordcuckSpinning : MonoBehaviour
{
    public float forceApplied = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
            other.attachedRigidbody.AddForce(other.attachedRigidbody.velocity.normalized * forceApplied, ForceMode.VelocityChange);
    }
}
