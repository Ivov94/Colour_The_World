using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToolTipScript : MonoBehaviour {

    //public string objectName;
    [TextArea]
    public string mainText;

    public GameObject toolTipWindow;
    public Text displayMainText;


    public void setActive(bool pActive)
    {
        toolTipWindow.SetActive(pActive);

        if (toolTipWindow != null)
        {
            displayMainText.text = mainText;
        }
    }

}
