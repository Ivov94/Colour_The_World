using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelScript : RobotScript {

    private static float robotVersion = 1;

    private TileScript tileToBeCanged;
    private float timeSinceInteract;
    public float timeToChange;
    private Colour input;

    private ExlamationMarkScript[] exlamationMarks;
    private bool exclamationMarkShown;

    private InfoToggleScript info;

    private bool open;

    // Use this for initialization
    void Start () {
        timeSinceInteract = 0;
        tileToBeCanged = GetComponentInParent<TileScript>();
        exlamationMarks = GetComponentsInChildren<ExlamationMarkScript>();
        info = GetComponentInChildren<InfoToggleScript>();
        info.SetNotActive();
        exclamationMarkShown = false;

        for (int i = 0; i < exlamationMarks.Length; i++)
        {
            exlamationMarks[i].SetNotActive();
        }
        open = true;
    }

	// Update is called once per frame
	void Update () {
		if (input != null)
        {
            timeSinceInteract += Time.deltaTime;
            if (timeSinceInteract >= timeToChange)
            {
                timeSinceInteract = 0;
                for (int i = 0; i < exlamationMarks.Length; i++)
                {
                    exlamationMarks[i].SetNotActive();
                }
                exclamationMarkShown = false;
                Change();
            }
            else if (timeSinceInteract + 1 >= timeToChange && !exclamationMarkShown)
            {
                for (int i = 0; i < exlamationMarks.Length; i++)
                {
                    exlamationMarks[i].SetActive();
                }
                exclamationMarkShown = true;
            }
        }
	}

    private void Change()
    {
        Debug.Log("Entered");
        tileToBeCanged.SetColour(input);
        input = null;
    }


    public override void ToggleInfo()
    {
        if (open)
        {
            info.ToggleActive();
        }
        
    }


    public override bool Interact()
    {
        return false;
    }

    public override bool Interact(Colour bucketColour)
    {
        if (!open)
        {
            return false;
        }
        input = bucketColour;
        open = false;
        UpdateSprite();
        info.ToggleActive();
        return true;
    }

    private void UpdateSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite sprite;
        if (open)
        {
            sprite = Resources.Load("Sprites/Robots/Funnel/Funnel_" + robotVersion + "_Open", typeof(Sprite)) as Sprite;
        }
        else
        {
            sprite = Resources.Load("Sprites/Robots/Funnel/Funnel_" + robotVersion + "_Closed", typeof(Sprite)) as Sprite;
        }
         
        spriteRenderer.sprite = sprite;
    }
}
