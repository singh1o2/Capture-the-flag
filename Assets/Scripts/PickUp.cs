using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public Transform theDest;

    void OnMouseDown(){
        GetComponent<Rigidbody>().useGravity = false; // turing off gravity when player picks up flag
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }

    void OnMouseUp(){
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true; // turing one gravity when player drops up flag
    }
}