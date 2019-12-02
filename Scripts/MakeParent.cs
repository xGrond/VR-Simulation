using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeParent : MonoBehaviour {

    public GameObject fork;

    public void MakeChild() {
        this.transform.parent = fork.transform;
    }
}
