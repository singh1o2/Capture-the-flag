using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damage;
    public float destructionTime;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        destructionTime -= Time.deltaTime;

        if (destructionTime <= 0) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player") {
            col.gameObject.GetComponent<PlayerController>().Damage(damage);
        }
        if (col.gameObject.tag != "Weapon" && col.gameObject.tag != "Projectile") {
            Instantiate(explosion,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
