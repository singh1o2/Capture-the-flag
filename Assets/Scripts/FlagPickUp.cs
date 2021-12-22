using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPickUp : MonoBehaviour
{
    private BoxCollider c;
    public bool e;

    void Start()
    {
        e = true;
        c = GetComponent<BoxCollider>();
    }

  
    public void setEnabled(bool enabled)
    {
        e = enabled;
        c.enabled = e;
    }
}
