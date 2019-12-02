using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vincController : MonoBehaviour {

    public float maxX, minX;
    [SerializeField] GameObject vinc;
    [SerializeField] GameObject ray;

    void MoveForward() {

    }

    void MoveBackward() {
        if (ray.transform.position.x >= minX)
        {
            Debug.Log(ray.transform.position.x);
            ray.transform.Translate(Vector3.left * Time.deltaTime * 5);
        }
    }

    void MoveLeft() {

    }

    void MoveRight() {

    }

    void moveUp() { 

    }

    void moveDown() {

    }

    private void Update()
    {
        MoveBackward();
    }
}
