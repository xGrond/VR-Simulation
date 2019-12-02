using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScripts : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}

    bool canStart;

    private void Awake()
    {
        canStart = false;
    }

    public void izgaraInitiated() {
        canStart = true;
    }

    // Update is called once per frame
    void Update () {
        if (canStart){
            gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, target.transform.position, 0.2f);
            gameObject.transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, target.gameObject.transform.rotation, 0.2f);
        }
    }

    
  

}
