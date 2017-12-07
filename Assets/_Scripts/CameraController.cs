using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;


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
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
