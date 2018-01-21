using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private Rigidbody2D rb;
    public float acceleration;
    public float maxSpeed;
    public float bucketManVersion;
    public float jumpForce;

    private Colour bodyColour;
    private Colour bucketColour;
    private Boolean jumpReady;

    private Game game;
    private float collisionTolerance;

    private RobotScript interactionRobot;

    private AudioSource audioSource;

    public AudioClip pickupAudioClip;
    [Range(0.0f,1.0f)]
    public float pickupVolume;

    public AudioClip goalPaintedAudioClip;
    [Range(0.0f, 1.0f)]
    public float goalPaintedVolume;

    public AudioClip flushingAudioClip;
    [Range(0.0f, 1.0f)]
    public float flushingVolume;

    public AudioClip swapColourAudioClip;
    [Range(0.0f, 1.0f)]
    public float swapColourVolume;

    public AudioClip jumpAudioClip;
    [Range(0.0f, 1.0f)]
    public float jumpVolume;

    // Use this for initialization
    void Start () {
        game = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<Game>();
        rb = GetComponent<Rigidbody2D>();
        bodyColour = new Colour("Grey");
        bucketColour = new Colour("Grey");
        jumpReady = false;
        collisionTolerance = 0.1f;
        interactionRobot = null;
        audioSource = GetComponent<AudioSource>();
    }
	

	void Update () {
		float movementX = Input.GetAxis("Horizontal");
        float movementY = 0;

        if (Input.GetKeyDown(KeyCode.Space) && jumpReady)
        {
            
            if (rb.velocity.y >= -0.1)
            {
                jumpReady = false;
                movementY = jumpForce;

                audioSource.volume = jumpVolume;
                audioSource.PlayOneShot(jumpAudioClip);

            }
            
        }


        if (movementX == 0)
        {
            rb.velocity = new Vector2(movementX/10, rb.velocity.y);
        }
        
        if (rb.velocity.x <= 0.01 && rb.velocity.x >= -0.01)
        {
            rb.AddForce(new Vector2(movementX * acceleration, 0), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(movementX * acceleration, 0));
        }
        

        rb.AddForce(new Vector2(0, movementY), ForceMode2D.Impulse);

        //we dont need it anymore
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
        }
        else if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
        }


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (SwapBodyBucketColour())
            {
                audioSource.volume = swapColourVolume;
                audioSource.PlayOneShot(swapColourAudioClip);
            }
        }

        if (Input.GetKeyDown(KeyCode.T) && interactionRobot != null)
        {
            
            bool colourUsed = false;
            if (bucketColour.colourName.Equals("Grey"))
            {
                interactionRobot.Interact();
            }
            else
            {
                colourUsed = interactionRobot.Interact(bucketColour);
            }
            
            if (colourUsed)
            {
                audioSource.volume = flushingVolume;
                audioSource.PlayOneShot(flushingAudioClip);
                bucketColour = new Colour("Grey");
                UpdateSprite();
            }
        }
    }

    private bool SwapBodyBucketColour()
    {
        if (bucketColour.colourName.Equals(bodyColour.colourName))
        {
            return false;
        }

        Colour swap = bucketColour;
        bucketColour = bodyColour;
        bodyColour = swap;

        UpdateSprite();

        return true;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.position.y + collision.gameObject.GetComponent<Collider2D>().bounds.extents.y 
            < transform.position.y - GetComponent<Collider2D>().bounds.extents.y + collisionTolerance)
        {
            rb.velocity = new Vector2(-collision.relativeVelocity.x, 0);
            jumpReady = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {



        if (other.gameObject.CompareTag("ColourTarget"))
        {
            if(game.ColourTarget(other, bucketColour))
            {
                audioSource.volume = goalPaintedVolume;
                audioSource.PlayOneShot(goalPaintedAudioClip);
                bucketColour = new Colour("Grey");
                UpdateSprite();
                
            }
        }
        else if (other.gameObject.CompareTag("BucketCollectible"))
        {
            audioSource.volume = pickupVolume;
            audioSource.PlayOneShot(pickupAudioClip);

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
        else if (other.gameObject.CompareTag("CameraChanger"))
        {
            if (!other.GetComponent<CameraChangerScript>().Switched)
            {
                other.GetComponent<CameraChangerScript>().Switch();
            }
            
        }
        else if (other.gameObject.CompareTag("Robot"))
        {

            other.GetComponent<RobotScript>().ToggleInfo();
            interactionRobot = other.GetComponent<RobotScript>();
            
        }
        else if (other.gameObject.CompareTag("Hazard"))
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            other.GetComponent<RobotScript>().ToggleInfo();
            interactionRobot = null;
        }
        else if (other.gameObject.CompareTag("CameraChanger"))
        {
            if (other.GetComponent<CameraChangerScript>().Switched)
            {
                other.GetComponent<CameraChangerScript>().Switch();
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
        Sprite sprite = Resources.Load("Sprites/Bucketman/" + bucketManVersion + "/Right/Bucketman" + bucketManVersion + "Body" + bodyColour.colourName + "Bucket" + bucketColour.colourName, typeof(Sprite)) as Sprite;
        spriteRenderer.sprite = sprite;
    }
}
