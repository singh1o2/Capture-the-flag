using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    
    public override void Fire() {
        if ((ammo > 0 || ammo == -1) && coolDownTimer == 0) {
            GameObject bulletInstance;
            for (float i = -0.25f; i <= 0.25f; i += 0.125f) {
                for (float j = -0.125f; j <= 0.125f; j += 0.25f) {
                    bulletInstance = Instantiate(bullet,transform.position,transform.rotation) as GameObject;
                    bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
                }
            }

            if (ammo > 0) {
                ammo -= 1;
            }

            coolDownTimer = coolDown;
        }
    }
}
