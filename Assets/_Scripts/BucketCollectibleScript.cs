using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketCollectibleScript : MonoBehaviour {

    public string startingColour;
    private Colour collectibleColour;
	
    void Start ()
    {
        collectibleColour = new Colour(startingColour);
    }

	// Update is called once per frame
	void Update () {
		
	}

    public Colour PickUp ()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        GetComponent<Collider2D>().enabled = false;
        return collectibleColour;
    }

    public Colour ExchangeColour (Colour newColour)
    {

        return collectibleColour;
    }
}
