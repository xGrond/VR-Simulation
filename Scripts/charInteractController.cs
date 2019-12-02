using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charInteractController : MonoBehaviour {

    public GameObject buttonVisual;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "interacter")
        {
            ForkliftGetInButtonActivate();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "interacter")
        {
            ForkliftGetInButtonDisactivate();
        }
    }

    void ForkliftGetInButtonActivate() {
        if (!buttonVisual.activeSelf)
        {
            buttonVisual.SetActive(true);
        }
        else return;
    }

    void ForkliftGetInButtonDisactivate() {
        if (buttonVisual.activeSelf)
        {
            buttonVisual.SetActive(false);
        }
        else return;
    }

}
