using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyMovement : MonoBehaviour
{
    private int direction = 1;
    private Vector3 movement;
    public float leftBound, rightBound;

    

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(2 * direction, 0f, 0f);
        transform.position = transform.position + movement * Time.deltaTime;

        if (transform.position.x < leftBound)
        {
            direction = Mathf.Abs(direction);
        }
        else if (rightBound < transform.position.x)
        {
            direction = Mathf.Abs(direction) * -1;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        //direction = direction * -1;

        //HEALTH
        

    }
}
