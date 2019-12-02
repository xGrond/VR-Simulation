using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class CustomInteraction : MonoBehaviour {

    public testScripts testScripts;
    public VRUIController VRUIController;

    protected virtual void OnHandHoverBegin(Hand hand)
    {
        bool showHint = false;

        // "Catch" the throwable by holding down the interaction button instead of pressing it.
        // Only do this if the throwable is moving faster than the prescribed threshold speed,
        // and if it isn't attached to another hand

        if (showHint)
        {
            hand.ShowGrabHint();
        }
    }

    protected virtual void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (startingGrabType != GrabTypes.None)
        {
            testScripts.izgaraInitiated();
            VRUIController.showDof1();
        }
    }
}
