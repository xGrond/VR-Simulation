using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionRaycast : MonoBehaviour {


    [SerializeField] forkliftComponentController forkCompControl;
    [SerializeField] fpsCharComponentController fpsCompControl;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            sendRaycast();
        }
	}

    void GetOutFromForklift() {
        forkCompControl.ShutdownForklift();
    }

    void getInToForklift() {
        forkCompControl.StartForklift();
        fpsCompControl.ShutdownCharComponents();
    }

    void sendRaycast() {
        RaycastHit isCastHit = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out isCastHit);

        if (hit)
        {
            //if name getinbutton transfor char into forklift
            Debug.Log(isCastHit.collider.transform.gameObject.name);
            if (isCastHit.collider.transform.gameObject.name == "getInButton")
            {
                getInToForklift();
            }
        }
    }


}
