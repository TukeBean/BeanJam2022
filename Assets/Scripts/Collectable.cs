using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public float spinSpeed = 0.5f;
    public Vector3 Rotaters;
    public float forceApplied = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Start!");
    }

    // Update is called once per frame
    void Update()
    {
        Spin();
    }

    void Spin()
    {
        Rotaters = new Vector3(0f, 0f, spinSpeed);
        transform.Rotate(Rotaters);
    }

    void OnTriggerStay(Collider other)
    {
         if (other.name == "Cube")
         {
            GameManager.instance.collectedCollectable();
            gameObject.SetActive(false);
         } 
    }
}
