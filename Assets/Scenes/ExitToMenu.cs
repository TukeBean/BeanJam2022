using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitToMenu : MonoBehaviour
{

    private SceneLoader sl;
    void Start()
    {
        sl = new SceneLoader();
    }

    void Update()
    {
        //load the main menu when you hit escape
        if (Input.GetKey("escape"))
        {
            sl.loadScene(Scenes.MainMenu);
        }
    }
}
