using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    public GameObject[] Collectables;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R)) 
        { 
            foreach(GameObject collectable in Collectables)
                collectable.SetActive(true);

            GameManager.instance.resetCollectable();
        }
    }
}
