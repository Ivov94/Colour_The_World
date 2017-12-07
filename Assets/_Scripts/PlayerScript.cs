using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public float maxSpeed;
    public float bucketManVersion;

    private Colour bodyColour;
    private Colour bucketColour;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        bodyColour = new Colour("Grey");
        bucketColour = new Colour("Grey");
    }
	
	// Update is called once per frame
	void Update () {
		float movementX = Input.GetAxis("Horizontal");
        float movementY = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movementY = 30;
        }

        Vector2 movement = new Vector2(movementX, movementY);
        rb.AddForce(movement * speed);
        if (rb.velocity.x > 5)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
        }
        else if (rb.velocity.x < -5)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
        }


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwapBodyBucketColour();
        }
    }

    private void SwapBodyBucketColour()
    {
        if (bucketColour.colourName.Equals(bodyColour.colourName))
        {
            return;
        }

        Colour swap = bucketColour;
        bucketColour = bodyColour;
        bodyColour = swap;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log("Sprites/Bucketman" + bucketManVersion + "Body" + bodyColour.colourName + "Bucket" + bucketColour.colourName);
        Sprite sprite = Resources.Load("Sprites/Bucketman" + bucketManVersion + "Body" + bodyColour.colourName + "Bucket" + bucketColour.colourName, typeof(Sprite)) as Sprite;
        spriteRenderer.sprite = sprite;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hi");
        //Destroy(other.gameObject);

        if (other.gameObject.CompareTag("ColourTarget"))
        {
            if(Game.ColourTarget(other, bucketColour))
            {
                bucketColour = new Colour("Grey");
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                Debug.Log("Sprites/Bucketman" + bucketManVersion + "Body" + bodyColour.colourName + "Bucket" + bucketColour.colourName);
                Sprite sprite = Resources.Load("Sprites/Bucketman" + bucketManVersion + "Body" + bodyColour.colourName + "Bucket" + bucketColour.colourName, typeof(Sprite)) as Sprite;
                spriteRenderer.sprite = sprite;
            }
        }
        else if (other.gameObject.CompareTag("BucketCollectible"))
        {
            Debug.Log("Hi2");
            if (bucketColour.colourName.Equals("Grey"))
            {
                bucketColour = other.GetComponent<BucketCollectibleScript>().PickUp();
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                Debug.Log("Sprites/Bucketman" + bucketManVersion + "Body" + bodyColour.colourName + "Bucket" + bucketColour.colourName);
                Sprite sprite = Resources.Load("Sprites/Bucketman" + bucketManVersion + "Body" + bodyColour.colourName + "Bucket" + bucketColour.colourName , typeof(Sprite)) as Sprite;
                spriteRenderer.sprite = sprite;
                Destroy(other.gameObject);
            }
        }
    }


    public Colour GetBodyColour()
    {
        return bodyColour;
    }
}
