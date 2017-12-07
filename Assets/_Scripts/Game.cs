using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Game {

    public int targetsToColour;
    private static Sprite[] sprites = Resources.LoadAll<Sprite>("");

    public static bool ColourTarget(Collider2D target, Colour colour)
    {
        TargetScript targetScript = target.GetComponent<TargetScript>();

        if (targetScript.AttemptColouring(colour))
        {
            return true;
        }

        return false;
    }

    public static bool CheckColour()
    {
        return true;
    }

}
