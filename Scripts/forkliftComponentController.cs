using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forkliftComponentController : MonoBehaviour {

    // All Components
    ForkController forkController;
    NewCarController newCarController;
    NewCarUserControl newCarUserControl;



	// Daha sonra metodları foreache çevir
	void Start () {
        forkController = GetComponent<ForkController>();
        newCarController = GetComponent<NewCarController>();
        newCarUserControl = GetComponent<NewCarUserControl>();
	}

    public void StartForklift() {
        forkController.enabled = true;
        newCarController.enabled = true;
        newCarUserControl.enabled = true;
    }

    // Update is called once per frame
    public void ShutdownForklift() {
        forkController.enabled = false;
        newCarController.enabled = false;
        newCarUserControl.enabled = false;
    }
}
