using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts; //[0] [1] [2]
    public int life;        //3
    private bool dead;

    private void Start()
    {
        life = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == true)
        {
            //SET DEAD CODE
            Debug.Log("YOU ARE DEAD!!!");
        }


    }

    void TakeDamage(int d)
    {

        if(life >= 1)
        {
            life -= d; //3-2-1 --> 2-1 --> 1-0= destroy
            Destroy(hearts[life].gameObject);
            if (life < 1)
            {
                dead = true;
            }
        }
        
    }
}
