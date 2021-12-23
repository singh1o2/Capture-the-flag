using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text HealthText;
    public Text AmmoText;
    public RectTransform HealthBar;
    public RectTransform CoolDownBar;
    
    // Start is called before the first frame update
    void Start()
    {
        HealthText.text = "0 HP";
        AmmoText.text = "No Weapon Equipped";
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = transform.parent.gameObject.GetComponent<PlayerController>().health + " HP";
        HealthBar.sizeDelta = new Vector2(transform.parent.gameObject.GetComponent<PlayerController>().health / 100f * 240, 40);
        
        if (transform.parent.gameObject.GetComponent<PlayerController>().weaponInstance != null) {
            float ammo = transform.parent.gameObject.GetComponent<PlayerController>().weaponInstance.GetComponent<Weapon>().ammo;
            float maxAmmo = transform.parent.gameObject.GetComponent<PlayerController>().weaponInstance.GetComponent<Weapon>().maxAmmo;
            string weaponName = transform.parent.gameObject.GetComponent<PlayerController>().weaponInstance.GetComponent<Weapon>().weaponName;
            float coolDown = transform.parent.gameObject.GetComponent<PlayerController>().weaponInstance.GetComponent<Weapon>().coolDown;
            float coolDownTimer = transform.parent.gameObject.GetComponent<PlayerController>().weaponInstance.GetComponent<Weapon>().coolDownTimer;

            if (ammo == -1) {
                AmmoText.text = weaponName + ": " + "Unlimited";
            } else {
                AmmoText.text = weaponName + ": " + ammo + " / " + maxAmmo;
            }

            if (ammo == 0) {
                CoolDownBar.sizeDelta = new Vector2(0, 40);
            } else {
                CoolDownBar.sizeDelta = new Vector2((coolDown - coolDownTimer) / coolDown * 240, 40);
            }
        }
    }
}
