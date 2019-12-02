using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsCharComponentController : MonoBehaviour {

    public Camera charCam;
    CharacterController charController;

    // Use this for initialization
    void Start () {
        charController = GetComponentInChildren<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShutdownCharComponents() {
        charCam.enabled = false;
        charController.enabled = false;
        MonoBehaviour[] comps = GetComponentsInChildren<MonoBehaviour>();
        foreach (MonoBehaviour c in comps)
        {
            c.enabled = false;
        }
    }

    public void ActivateCharacter() {
        charCam.enabled = true;
        MonoBehaviour[] comps = GetComponentsInChildren<MonoBehaviour>();
        foreach (MonoBehaviour c in comps)
        {
            c.enabled = true;
        }
    }

}
