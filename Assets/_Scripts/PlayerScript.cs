using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public float maxSpeed;
    public float bucketManVersion;
    public float jumpForce;

    private Colour bodyColour;
    private Colour bucketColour;
    private Boolean jumpReady;

    private float collisionTolerance;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        bodyColour = new Colour("Grey");
        bucketColour = new Colour("Grey");
        jumpReady = false;
        collisionTolerance = 0.1f;
    }
	
	// Update is called once per frame
	void Update () {
		float movementX = Input.GetAxis("Horizontal");
        float movementY = 0;

        if (Input.GetKeyDown(KeyCode.Space) && jumpReady)
        {
            
            if (rb.velocity.y >= -0.1)
            {
                jumpReady = false;
                movementY = jumpForce;
            }
            
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

        UpdateSprite();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.position.y + collision.gameObject.GetComponent<Collider2D>().bounds.extents.y 
            < transform.position.y - GetComponent<Collider2D>().bounds.extents.y + collisionTolerance)
        {
            jumpReady = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ColourTarget"))
        {
            if(Game.ColourTarget(other, bucketColour))
            {
                bucketColour = new Colour("Grey");
                UpdateSprite();
                
            }
        }
        else if (other.gameObject.CompareTag("BucketCollectible"))
        {
            if (bucketColour.colourName.Equals("Grey"))
            {
                bucketColour = other.GetComponent<BucketCollectibleScript>().PickUp();
                UpdateSprite();
                Destroy(other.gameObject);
            }
            else
            {
                bucketColour = other.GetComponent<BucketCollectibleScript>().PickUp(bucketColour);
                UpdateSprite();
            }
        }
    }


    public Colour GetBodyColour()
    {
        return bodyColour;
    }

    public void UpdateSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite sprite = Resources.Load("Sprites/Bucketman/" + bucketManVersion + "/Bucketman" + bucketManVersion + "Body" + bodyColour.colourName + "Bucket" + bucketColour.colourName, typeof(Sprite)) as Sprite;
        spriteRenderer.sprite = sprite;
    }
}
