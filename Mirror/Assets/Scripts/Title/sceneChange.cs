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
        StartCoroutine(StartDelay());
    }

     public void LearnGame()
    {
        StartCoroutine(TutorialDelay());
    }

     public void creditsGame()
    {
        StartCoroutine(CreditsDelay());
    }

    public void titleGame()
    {
        StartCoroutine(TitleDelay());
    }

    public void endGame()
    {
        StartCoroutine(end());
    }

    public IEnumerator end()
    {
        yield return new WaitForSeconds(.3f);
        Application.Quit();
        StopCoroutine(TitleDelay());
    }

    public IEnumerator TitleDelay()
    {
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene("Title");
        StopCoroutine(TitleDelay());
    }

    public IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene("Game");
        StopCoroutine(StartDelay());
    }

    public IEnumerator TutorialDelay()
    {
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene("Tutorial");
        
        StopCoroutine(TutorialDelay());
    }

    public IEnumerator CreditsDelay()
    {
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene("Credits");
        StopCoroutine(CreditsDelay());
    }
}
