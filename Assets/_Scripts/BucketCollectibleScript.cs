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

    public Colour PickUp(Colour colour)
    {
        Colour swap = collectibleColour;
        collectibleColour = colour;
        UpdateSprite();
        return swap;
    }

    public void UpdateSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite sprite = Resources.Load("Sprites/Bucket_Collectible/1.1/Bucket_Collectible_" + collectibleColour.colourName, typeof(Sprite)) as Sprite;
        spriteRenderer.sprite = sprite;
    }
}
