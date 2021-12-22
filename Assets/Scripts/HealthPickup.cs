using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private BoxCollider c;
    public bool e;

    void Start() {
        e = true;
        c = GetComponent<BoxCollider>();
    }

    void Update() {
        transform.Rotate (0,50*Time.deltaTime,0);
    }

    public void setEnabled(bool enabled) {
        e = enabled;
        c.enabled = e;
    }
}
