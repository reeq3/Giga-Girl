using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float life = 3;


    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        //for Gorund and Air enemy damage
        if (collision.collider.gameObject.tag == "Enemy")
        {
            //Destroy(collision.gameObject);

            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(5);
        }
        //For turret damage
        if (collision.collider.gameObject.tag == "Enemy")
        {
            //Destroy(collision.gameObject);

            collision.gameObject.GetComponent<TurretHealth>().TakeDamage(5);
        }

    }
}
