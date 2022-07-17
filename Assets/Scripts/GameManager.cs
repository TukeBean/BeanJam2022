using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int CollectableMax = 5;
    private int CollectableCount = 0;
    private Text thisText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        thisText = GameObject.Find("CC").GetComponent<Text>();
        thisText.text = "Chips " + CollectableCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collectedCollectable()
    {
        CollectableCount++;
        Debug.Log(CollectableCount);
        thisText.text = "Chips " + CollectableCount;
    }

        public void resetCollectable(int score)
    {
        CollectableCount = score;
        Debug.Log(CollectableCount);
        thisText.text = "Chips " + CollectableCount;
    }
}
