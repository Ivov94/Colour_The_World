using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Vector2 imgSizeDelta = gameObject.GetComponent<Image>().rectTransform.sizeDelta;
        gameObject.GetComponent<BoxCollider2D>().size = imgSizeDelta;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
