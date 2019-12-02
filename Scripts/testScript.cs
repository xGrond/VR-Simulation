using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour {

    public Transform target;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = target.transform.position;
        this.transform.rotation = target.transform.rotation;
    }

    private void FixedUpdate()
    {
        this.transform.position = target.transform.position;
        this.transform.rotation = target.transform.rotation;
    }

    private void LateUpdate()
    {
        this.transform.position = target.transform.position;
        this.transform.rotation = target.transform.rotation;
    }
}
