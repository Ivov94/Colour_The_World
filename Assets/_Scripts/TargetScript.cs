using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

    public string colour;
    private Colour targetColour;

	// Use this for initialization
	void Start () {
        targetColour = new Colour(colour);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool AttemptColouring(Colour colour)
    {
        if (colour.colourName.Equals(targetColour.colourName))
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Sprite sprite = Resources.Load("Sprites/Target_1_CompletedRed", typeof(Sprite)) as Sprite;

            spriteRenderer.sprite = sprite;
            return true;
        }
       
        return false;
    }
}
