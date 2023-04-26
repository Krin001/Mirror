using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.height, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }

     public void LearnGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

     public void creditsGame()
    {
        SceneManager.LoadScene("Credits");
    }

    public void titleGame()
    {
        SceneManager.LoadScene("Title");
    }
}
