using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forkliftYolController : MonoBehaviour {

    bool timerActive;
    float time;
    public float delayTime;
    public VRUIController VRUIController;

    void yolTimer()
    {
        if (!timerActive) return;

        time += Time.deltaTime;
        //do smh
        if (time >= delayTime)
        {
            VRUIController.hideYolUyari();
            timerActive = false;
            time = 0;
        }
    }

    private void Update()
    {
        yolTimer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "forkOn") {
            VRUIController.showYolUyari();
            timerActive = true;
        }
    }
}

