using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCharacterCode : MonoBehaviour
{
    public float speedMovement = 5.0f;
    public float speedRotation = 200.0f;
    public float jump;
    public Rigidbody rb;
    public Animator anim;
    public float x, y;

    public bool playerIsOnTheGround = true;

    //HEALTH
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private GameObject deathEffect, hitEffect;
    private float currentHealth;

    [SerializeField] private HealthBar healthbar;

    //LIFE
    public GameObject[] hearts; //[0] [1] [2]
    public int life;        //3
    private bool dead;

    //RESPAWN
    [SerializeField] GameObject Player;

    [SerializeField] Transform spawnPoint;

    [SerializeField] float spawnValue;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        // Refrences the rigidbody the player has as a component to support jumping
        rb = GetComponent<Rigidbody>();

        currentHealth = maxHealth;

        healthbar.UpdateHealthBar(maxHealth, currentHealth);

        life = hearts.Length;

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //transform.Rotate(0, x * Time.deltaTime * speedRotation, 0);
        transform.Translate(0, 0, x * Time.deltaTime * speedMovement);

        //anim.SetFloat("SpeedX", y);
        anim.SetFloat("SpeedY", x);

        //Moving left and right

        // Whenever the user presses A...
        // move the player to the left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(0, 0, -speedMovement);
        }
        // Whenever the user presses D...
        // move the player to the right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0, 0, speedMovement);
        }

        //Jumping and crouching

        // Whenever the user presses W...
        // the player will jump
        if (Input.GetKeyDown(KeyCode.W) && playerIsOnTheGround)
        {
            rb.AddForce(new Vector3(0, 8, 0), ForceMode.Impulse);//the force of the jump
            playerIsOnTheGround = false; //once player is in the air, makes the bool false
        }

        //Life System
        if (dead == true)
        {
            //SET DEAD CODE
            Debug.Log("YOU ARE DEAD!!!");
        }


        //RESPAWN SYSTEM
        if (Player.transform.position.y < -spawnValue)
        {
            //life--;
            //Destroy(hearts[life].gameObject);
            //RespawnPoint();

            if (life >= 1)
            {
                life--; //3-2-1 --> 2-1 --> 1-0= destroy
                Destroy(hearts[life].gameObject);

                RespawnPoint();
            }
            else if (life <= 1)
            {
                dead = true;
                Destroy(gameObject);
            }

        }
    }

    void RespawnPoint()
    {
        transform.position = spawnPoint.position;
        currentHealth = maxHealth;
        //healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    

    void OnCollisionEnter(Collision obj)
    {

        //checks if player landed on ground
        if (obj.gameObject.tag == "Ground")
        {
            playerIsOnTheGround = true;
        }

        //HEALTH
        currentHealth -= 10;

        if(obj.gameObject.tag == "Enemy")
        {
            if (currentHealth <= 0 && life >= 1)
            {
                life--; //3-2-1 --> 2-1 --> 1-0= destroy
                Destroy(hearts[life].gameObject);

                RespawnPoint();
            }

            if (currentHealth <= 0 && life <= 1)
            {
                dead = true;
                Destroy(gameObject);
            }
            else
            {
                healthbar.UpdateHealthBar(maxHealth, currentHealth);
                //Instantiate(hitEffect, transform.position, Quaternion.identity);
            }
        }

        //for Gorund and Air enemy damage
        if (obj.collider.gameObject.tag == "EnemyProjectile")
        {
            //Destroy(collision.gameObject);

            obj.gameObject.GetComponent<EnemyHealth>().TakeDamage(15);
        }




        // If reach end of level
        if (obj.gameObject.name == "VictoryBorder")
        {
            // Victory animation and next level

            // Victory Animation

            // Next Level
            Debug.Log("Player hit end of level, starting next level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void OnCollisionExit(Collision obj)
    {

    }
}
