using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    public GameObject[] Collectables;
    public int checkpoint = 0;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R)) 
        { 
            resetCollectables();
        }
    }

    public void NextCheckpoint()
    {
        checkpoint++;
    }

    public void resetCollectables()
    {
        for (int i = 0; i < Collectables[checkpoint].transform.childCount; i++)
            {
                Collectables[checkpoint].transform.GetChild(i).gameObject.SetActive(true);
            }

            score = 0;
            for (int i = 0; i < checkpoint; i++)
            {
                for (int j = 0; j < Collectables[i].transform.childCount; j++)
                {
                    if(!Collectables[i].transform.GetChild(j).gameObject.active)
                        score++;
                }
            }

            // foreach(GameObject collectable in Collectables.)
            //     collectable.SetActive(true);

            GameManager.instance.resetCollectable(score);
    }
}
