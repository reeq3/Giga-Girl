using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{

    AudioSource AS;
    public AudioClip Coin1, Coin2;


    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            //Just uses the first Coin sound only
            //AS.PlayOneShot(Coin1);

            //use a random function to randomize the coin sound between Coin1 and Coin2
            if (Random.Range(0, 2) == 0)
            {
                AS.PlayOneShot(Coin1);
            }
            else
            {
                AS.PlayOneShot(Coin2);
            }
            //Destoroy Coin object after colliding with it
            Destroy(collision.gameObject);
            
        }
    }



}
