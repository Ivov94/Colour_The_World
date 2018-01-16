using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Game : MonoBehaviour{

    public int targetsToColour;
    private Sprite[] sprites;
    public Transform canvasEnd;

    [Range(0.0f, 1.0f)]
    public float bckgrndMusicVolume;


    private void Start()
    {
        targetsToColour = GameObject.FindGameObjectsWithTag("ColourTarget").Length;
        
        sprites = Resources.LoadAll<Sprite>("");

        AudioSource audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = bckgrndMusicVolume;
        audioSrc.Play();

    }

    public bool ColourTarget(Collider2D target, Colour colour)
    {
        TargetScript targetScript = target.GetComponent<TargetScript>();

        if (targetScript.AttemptColouring(colour))
        {
            targetsToColour--;
            if (targetsToColour <= 0)
            {
                if (canvasEnd != null)
                {
                    canvasEnd.gameObject.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                    Debug.Log("canvasEnd NOT SET");

            }

            
            return true;
        }

        return false;
    }

    public static bool CheckColour()
    {
        return true;
    }

}
