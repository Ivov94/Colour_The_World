using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Game : MonoBehaviour{

    public int targetsToColour;
    private Sprite[] sprites;
    public Transform canvasEnd;


    private void Start()
    {
        targetsToColour = GameObject.FindGameObjectsWithTag("ColourTarget").Length;
        
        sprites = Resources.LoadAll<Sprite>("");

    }

    public bool ColourTarget(Collider2D target, Colour colour)
    {
        TargetScript targetScript = target.GetComponent<TargetScript>();

        if (targetScript.AttemptColouring(colour))
        {
            targetsToColour--;
            if (targetsToColour <= 0)
            {
                canvasEnd.gameObject.SetActive(true);
                Time.timeScale = 0;
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
