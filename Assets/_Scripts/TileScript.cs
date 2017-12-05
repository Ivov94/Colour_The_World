using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    public string startingColour;
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
}
