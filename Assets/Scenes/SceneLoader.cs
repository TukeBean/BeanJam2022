using UnityEngine.SceneManagement;
using UnityEngine;


public enum Scenes
{
    MainMenu, levelOne, Credits, Tutorial, SplashScreen
}

public class SceneLoader : MonoBehaviour
{

    //load with enum, used in code 
    public void loadScene(Scenes name)
    {
        SceneManager.LoadScene(name.ToString());
    }

    //load with string - used for menu buttons, names defined in class 
      public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

}
