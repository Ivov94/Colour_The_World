using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Game {

    public int targetsToColour;
    private static Sprite[] sprites = Resources.LoadAll<Sprite>("");

    public static bool ColourTarget(Collider2D target, Colour colour)
    {
        SpriteRenderer spriteRenderer = target.GetComponent<SpriteRenderer>();
        Sprite sprite = Resources.Load("Sprites/Target_1_CompletedRed", typeof(Sprite)) as Sprite;
        Debug.Log(sprites.Length);

        spriteRenderer.sprite = sprite;
        return true;
    }

    public static bool CheckColour()
    {
        return true;
    }

}
