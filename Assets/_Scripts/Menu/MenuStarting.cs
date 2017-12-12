using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStarting : MonoBehaviour {

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
