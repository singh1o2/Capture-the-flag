using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Weapon : NetworkBehaviour
{
    public GameObject bullet;

    public float speed;
    public int maxAmmo;
    public int ammo;
    public float coolDown;
    public string weaponName;
    public float coolDownTimer;

    void Start() {
        coolDownTimer = 0;
        ammo = maxAmmo;
    }

    void Update()
    {
       /* Debug.Log(isLocalPlayer);
        if (Input.GetMouseButton(0)) {
            Fire();
        }
        */
        coolDownTimer = Mathf.Max(0f, coolDownTimer - Time.deltaTime); 
    }

    public virtual void Fire() {
        if ((ammo > 0 || ammo == -1) && coolDownTimer == 0) {
            GameObject bulletInstance;

            bulletInstance = Instantiate(bullet,transform.position,transform.rotation) as GameObject;
            bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
            if (ammo > 0) 
            {
                ammo -= 1;
            }
            coolDownTimer = coolDown;
        }
    }

    public void FillAmmo() {
        ammo = maxAmmo;
    }
}
