using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RobotScript : MonoBehaviour {

    public abstract bool Interact();

    public abstract bool Interact(Colour bucketColour);

    public abstract void ToggleInfo();
}
