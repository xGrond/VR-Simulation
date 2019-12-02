using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class IncikButtons : MonoBehaviour {

    public VRCharController VRCharController;

    protected virtual void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (startingGrabType != GrabTypes.None)
        {
            VRCharController.leftForklift(detectButton());
        }
    }

    int detectButton() {
        if (gameObject.name == "solInCik") return 0;
        else return 1;
    }
}
