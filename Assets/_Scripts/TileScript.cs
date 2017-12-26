using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    public string startingColour;
    public int TileVersion;
    public int Length;
    public int Height;

    private Colour tileColour;
    private Collider2D collider;

    private PlayerScript player;

	// Use this for initialization
	void Start () {
        tileColour = new Colour(startingColour);
        collider = GetComponent<Collider2D>();

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        player = players[0].GetComponent<PlayerScript>();

    }
	
	// Update is called once per frame
	void Update () {
		if (player.GetBodyColour().colourName.Equals(tileColour.colourName) && !player.GetBodyColour().colourName.Equals("Grey"))
        {
            collider.enabled = false;
        }
        else
        {
            collider.enabled = true;
        }
	}

    private void UpdateSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite sprite = Resources.Load("Sprites/Tiles/Tile_" + TileVersion + "_" + tileColour.colourName + "_" + Length + "x" + Height, typeof(Sprite)) as Sprite;
        spriteRenderer.sprite = sprite;
    }


    public Colour GetTileColour()
    {
        return tileColour;
    }

    public void SetColour(Colour newColour)
    {
        tileColour = newColour;
        UpdateSprite();
    }
}
