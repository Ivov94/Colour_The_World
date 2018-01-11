using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;


    public float offsetX;
    public float offsetY;

    public float maxY;
    public float minY;

    private Vector3 offset;


    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        player = players[0].GetComponent<PlayerScript>().gameObject;
        offset = transform.position - player.transform.position;
    }


    void LateUpdate()
    {

        Vector3 newPosition = transform.position;

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (transform.position.x + offsetX < player.transform.position.x)
        {
            newPosition.x +=  player.transform.position.x - (transform.position.x + offsetX);
        }

        if (transform.position.x - offsetX > player.transform.position.x)
        {
            newPosition.x += player.transform.position.x - (transform.position.x - offsetX);
        }

        if (transform.position.y + offsetY < player.transform.position.y)
        {
            newPosition.y += player.transform.position.y - (transform.position.y + offsetY);
        }

        if (transform.position.y - offsetY > player.transform.position.y)
        {
            newPosition.y += player.transform.position.y - (transform.position.y - offsetY);
        }

        if (newPosition.y < minY)
        {
            newPosition.y = minY;
        }
        if (newPosition.y > maxY)
        {
            newPosition.y = maxY;
        }


        transform.position = newPosition;
    }
}
