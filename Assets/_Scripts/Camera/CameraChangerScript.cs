using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangerScript : MonoBehaviour {

    public Camera cameraToSwitchBack;
    public Camera cameraToSwitchTo;

    public bool Switched
    {
        get; private set;
    }

	// Use this for initialization
	void Start () {
        Switched = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void Switch()
    {
        if (Switched)
        {
            Switched = false;
            cameraToSwitchBack.enabled = true;
            cameraToSwitchTo.enabled = false;
        }
        else
        {
            Switched = true;
            cameraToSwitchBack.enabled = false;
            cameraToSwitchTo.enabled = true;
        }
    }
}
