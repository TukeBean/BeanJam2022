using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lordCopy : MonoBehaviour
{
    public float forceApplied = 20f;
    public float upwardForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
            other.attachedRigidbody.AddForce(new Vector3(0f, upwardForce, 0f) * forceApplied, ForceMode.VelocityChange);
    }
}
