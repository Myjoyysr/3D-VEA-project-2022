using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10;
    public Rigidbody bullet;
    //public LayerMask ignoreOthers = ~(1 << 9 | 1 << 10);

    public void Fire()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;
    }

    void Update()
    {

        if (Input.GetButtonDown("LT") || Input.GetButtonDown("RT") || Input.GetButtonDown("LB"))
        {
            Fire();
            Debug.Log("FIRING");
        }
    }
}


