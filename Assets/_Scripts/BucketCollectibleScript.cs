using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketCollectibleScript : MonoBehaviour {

    public string startingColour;
    private Colour collectibleColour;
    private float centerY;
    private bool floatingUp;

    void Start ()
    {
        collectibleColour = new Colour(startingColour);
        centerY = transform.position.y;
        floatingUp = true;
    }

	// Update is called once per frame
	void Update () {
        if (transform.position.y < centerY - 0.1)
        {
            floatingUp = true;
        }
		else if (transform.position.y > centerY + 0.1)
        {
            floatingUp = false;
        }

        if (floatingUp)
        {
            transform.position += new Vector3(0, 0.01f, 0);
        }
        else
        {
            transform.position -= new Vector3(0, 0.01f, 0);
        }

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
