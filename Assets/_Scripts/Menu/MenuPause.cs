using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {

    public Transform canvas;

    private Scene currentScene;

	// Use this for initialization
	void Start () {
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (! canvas.gameObject.activeInHierarchy)
            {
                openMenu();
            }
            else
            {
                closeMenu();
            }
        }
    }

    private void openMenu()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void closeMenu()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void resume()
    {
        closeMenu();
    }

    public void restartCurrentScene()
    {
        closeMenu();
        SceneManager.LoadScene(currentScene.name);
        
    }

    public void openStartingMenu()
    {
        closeMenu();
        SceneManager.LoadScene("MenuStarting");
        
    }

    public void openLevelMenu()
    {
        closeMenu();
        SceneManager.LoadScene("MenuSelectLevel");
    }

}
