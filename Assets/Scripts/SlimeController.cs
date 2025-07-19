using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform respawnPoint;

    public int health; //amount of hits needed to kill
    public int points;  //points awarded when killed

    public float speed; 

    private Rigidbody2D rb;

    public GameObject player;

    private bool movingRight; //true means its right, false means it left
    public bool isMoving; //true means its moving, false means to not move
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movingRight = true;
        isMoving = true;
    }

    void FixedUpdate()
    {
        //move and flip the sprite based on its direction
        if (isMoving)
        {
            if (movingRight)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                rb.linearVelocityX = speed;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
                rb.linearVelocityX = -speed;
            }
        }
        else
        {
            rb.linearVelocityX = 0;
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TurnAround"))
        {
            //change the direction
            movingRight = !movingRight;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            //destroy the enemy
            SoundManager.Instance.PlayKill();

            //make enemy stop
            isMoving = false;
            //prevent this object from collliding with player 
            //gameObject.layer = 13; // 13 is enemy dead
            gameObject.layer = LayerMask.NameToLayer("Dead");
            //give gamemanager points
            GameManager.Instance.AddScore(points);
            //play sound
            //visually mark the enemy dead -- animation, flash , change color
            GetComponent<Animator>().SetTrigger("death");

            //destroy this object in time        
            Destroy(gameObject, 1f);
        }

    }

}
