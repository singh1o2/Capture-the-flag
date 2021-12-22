using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerController : NetworkBehaviour
{
    public float height;
    public float health;
    private float interval =0.5f;
    private float updateRate = 0.5f;
    private float speed;
    private bool keyState = false;
    private Vector3 moveDirection;
    private CharacterController controller;
    Animator animator;

    private Transform parent;
    
    public GameObject destination;
    public GameObject weapon;
    public GameObject weaponInstance;
    public GameObject weaponSlot;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        parent = gameObject.transform.Find("Weapon Slot");

        speed = 2;

        health = 100f;
        
      //  EquipWeapon(weapon);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            gameObject.transform.Find("Camera").gameObject.SetActive(false);
            return;
        }
        gameObject.transform.Find("Camera").gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
            keyState = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            speed = 2;

            keyState = false;

        }
        if (keyState)
        {
            if (Time.time > updateRate && speed < 15)
            {
                updateRate = Time.time+interval;
                speed += 4;
            }
            if (speed == 14)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);
            }
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        moveDirection = transform.right*moveX +transform.forward*moveZ;
        if (moveZ > 0&& !(Input.GetKey(KeyCode.UpArrow)))
        {
            controller.Move(moveDirection * Time.deltaTime*speed);
        }
        
    }
    void FixedUpdate()
    {
        //ray starts at player position and points down
        Ray ray = new Ray(transform.position, Vector3.down);

        //will store info of successful ray cast
        RaycastHit hitInfo;

        //terrain should have mesh collider and be on custom terrain 
        //layer so we don't hit other objects with our raycast
        LayerMask layer = 1 << LayerMask.GetMask("Terrain");
        //cast ray
        if (!controller.isGrounded && Physics.Raycast(ray, out hitInfo, layer))
        {
            //get where on the z axis our raycast hit the ground
            float y = hitInfo.point.y;
            //copy current position into temporary container
            Vector3 pos = transform.position;

            //change z to where on the z axis our raycast hit the ground
            pos.y = y;

            //override our position with the new adjusted position.
            transform.position = pos;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit col) {
        if (col.gameObject.tag == "Weapon Pickup")
        {
            if (col.gameObject.GetComponent<WeaponPickup>().e) {
                EquipWeapon(col.gameObject.GetComponent<WeaponPickup>().weapon);
                col.gameObject.GetComponent<WeaponPickup>().setEnabled(false);
            }
        }
        if (col.gameObject.tag == "Flag")
        {
            if (col.gameObject.GetComponent<FlagPickUp>().e)
            {
                col.gameObject.transform.SetParent(destination.transform);
                col.gameObject.GetComponent<FlagPickUp>().setEnabled(false);
            }
        }
        if (col.gameObject.tag == "Ammo Pickup")
        {
            if (col.gameObject.GetComponent<AmmoPickup>().e) {
                weaponInstance.GetComponent<Weapon>().FillAmmo();
                col.gameObject.GetComponent<AmmoPickup>().setEnabled(false);
            }
        }
        if (col.gameObject.tag == "Health Pickup")
        {
            if (col.gameObject.GetComponent<HealthPickup>().e) {
                col.gameObject.GetComponent<HealthPickup>().setEnabled(false);
            }
        }
    }


    void EquipWeapon(GameObject w) {
        weapon = w;
        Destroy(weaponInstance);
        weaponInstance = Instantiate(weapon, parent.position, parent.rotation) as GameObject;
        Vector3 scale = weaponInstance.transform.localScale;
        weaponInstance.transform.SetParent(parent);
        weaponInstance.transform.localScale = scale;
    }

    public void Damage(float d) {
        health -= d;
    }
}
