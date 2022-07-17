using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayStickShuffle : MonoBehaviour
{

    public float maxMove = 100;
    private int count = 0;
    public float speed = 0.01f;
    public float delay = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(delay > 0)
            delay--;
        else
        {
            if(count > maxMove*2)
                count = 0;

            count++;
            if (count < maxMove)
            {
                // movement = new Vector3(0f, 0f, speed);
                transform.position = transform.position + new Vector3(speed, 0f, 0f);
            }else{
                // movement = new Vector3(0f, 0f, -speed);
                // transform.position(movement);
                transform.position = transform.position + new Vector3(-speed, 0f, 0f);
            }
        }
            

    }
}
    