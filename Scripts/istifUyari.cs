using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class istifUyari : MonoBehaviour {

    public VRUIController VRUIController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "forkOn") {
            VRUIController.showIstifCanvas();
        }
    }
}
