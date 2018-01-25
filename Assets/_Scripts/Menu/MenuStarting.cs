using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStarting : MonoBehaviour {


    public void openTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void open1Level()
    {
        SceneManager.LoadScene("Level1");
    }

    public void open2Level()
    {
        SceneManager.LoadScene("Level2");
    }

    public void open3Level()
    {
        SceneManager.LoadScene("Level3");
    }

    public void open4Level()
    {
        SceneManager.LoadScene("Level4");
    }

    public void open5Level()
    {
        SceneManager.LoadScene("Level5");
    }

    public void open6Level()
    {
        SceneManager.LoadScene("Level6");
    }

    public void open7Level()
    {
        SceneManager.LoadScene("Level7");
    }

    public void open8Level()
    {
        SceneManager.LoadScene("Level8");
    }



    public void openStartingMenu()
    {
        SceneManager.LoadScene("MenuStarting");
    }

    public void openLevelMenu()
    {
        SceneManager.LoadScene("MenuSelectLevel");
    }

    public void exitGame()
    {
        Debug.Log("Clicked quit");
        Application.Quit();
    }
}
