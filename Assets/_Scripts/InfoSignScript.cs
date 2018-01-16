using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSignScript : MonoBehaviour {

    private ToolTipScript toolTipScript;

    // Use this for initialization
    void Start()
    {
        toolTipScript = GetComponent<ToolTipScript>();

    }

    void OnTriggerEnter2D(Collider2D pOther)
    {
        toolTipScript.setActive(true);
    }


    void OnTriggerExit2D(Collider2D pOther)
    {
        toolTipScript.setActive(false);
    }

}
