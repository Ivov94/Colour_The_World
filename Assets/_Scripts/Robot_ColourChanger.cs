using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_ColourChanger : MonoBehaviour {

    private static float robotVersion = 1;

    public string startingColourOutputTank;
    public string startingColourInputTank;

    public float timeBetweenChanges;

    private TileScript tileToBeCanged;
    private Colour colourOutput;
    private Colour colourInput;
    private float timeSinceLastChange;

    private ExlamationMarkScript[] exlamationMarks;
    private bool exclamationMarkShown;

    // Use this for initialization
    void Start () {
        colourOutput = new Colour(startingColourOutputTank);
        colourInput = new Colour(startingColourInputTank);
        tileToBeCanged = GetComponentInParent<TileScript>();
        exlamationMarks = GetComponentsInChildren<ExlamationMarkScript>();
        exclamationMarkShown = false;
        for (int i = 0; i < exlamationMarks.Length; i++)
        {
            exlamationMarks[i].SetNotActive();
        }

    }
	
	// Update is called once per frame
	void Update () {
        timeSinceLastChange += Time.deltaTime;
		if (timeSinceLastChange >= timeBetweenChanges)
        {
            timeSinceLastChange -= timeBetweenChanges;
            for (int i = 0; i < exlamationMarks.Length; i++)
            {
                exlamationMarks[i].SetNotActive();
            }
            exclamationMarkShown = false;
            Change();
        }
        else if (timeSinceLastChange + 1 >= timeBetweenChanges && !exclamationMarkShown)
        {
            for (int i = 0; i < exlamationMarks.Length; i++)
            {
                exlamationMarks[i].SetActive();
            }
            exclamationMarkShown = true;
        }
	}

    private void UpdateSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite sprite = Resources.Load("Sprites/Robots/ColourChanger/Robot_" + robotVersion + "_In" + colourInput.colourName + "Out" + colourOutput.colourName, typeof(Sprite)) as Sprite;
        spriteRenderer.sprite = sprite;
    }

    private void Change()
    {
        Colour drawnFromTile = new Colour(tileToBeCanged.GetTileColour().colourName);

        tileToBeCanged.SetColour(colourOutput);
        colourOutput = colourInput;
        colourInput = drawnFromTile;

        UpdateSprite();
    }
}
