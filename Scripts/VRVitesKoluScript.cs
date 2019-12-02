using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class VRVitesKoluScript : MonoBehaviour {

    public Vector3 reverseLoc;
    public Vector3 forwardLoc;
    public NewCarUserControl newCarUserControl;

    protected virtual void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (startingGrabType != GrabTypes.None)
        {
            if (newCarUserControl.reverseMode)
            {
                forward();
            }
            else reverse();
        }
    }

    void reverse() {
        gameObject.transform.localRotation = Quaternion.Euler(reverseLoc.x, reverseLoc.y, reverseLoc.z);
        newCarUserControl.reverseMode = true;
    }

    void forward() {
        gameObject.transform.localRotation = Quaternion.Euler(forwardLoc.x, forwardLoc.y, forwardLoc.z);
        newCarUserControl.reverseMode = false;
    }
}
