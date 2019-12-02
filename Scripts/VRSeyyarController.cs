using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class VRSeyyarController : MonoBehaviour {

    Rigidbody rb;
    bool sabitlendi;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sabitlendi = false;
    }

    protected virtual void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (startingGrabType != GrabTypes.None)
        {
            sabitle();
        }
    }

    void sabitle() {
        sabitlendi = true;
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    void notStable() {
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "forkOn")
        {
            if (!sabitlendi) {
                notStable();
            }
        }
    }


}
