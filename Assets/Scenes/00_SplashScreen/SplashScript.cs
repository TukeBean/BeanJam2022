using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int Timeout = 2;
    private SceneLoader sl;
    void Start()
    {
        sl = new SceneLoader();
        Invoke("loadTitle", Timeout);
    }

    private void loadTitle()
    {
        sl.loadScene(Scenes.MainMenu);
    }

    void Update()
    {

    }

}
