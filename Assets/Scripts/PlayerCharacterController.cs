
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerCharacterController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public bool isGrounded; //todo turn private
    public Vector3 groundCheckPosition; //position to check for ground
    public float groundCheckRadius; //radius of where to check for ground
    public LayerMask groundLayers; //what layers make up the gounrd objects

    public Animator animator;

    public Transform respawnPoint;


    private bool facingRight; //if the player is facing right then true
    private Rigidbody2D rb;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.state == GameManager.GameState.Playing)
        {
            MovePlayer();
        }

        else if (Input.GetKeyDown(KeyCode.T))
        {
            GameManager.Instance.StartPlaying();
        }
    }

    private void FixedUpdate()
    {
        // performing ground check

        //reset grounded
        isGrounded = false;

        // check for collision
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + groundCheckPosition, groundCheckRadius, groundLayers);

        //if at least 1 collider returned
        if (colliders.Length >= 1)
        {
            isGrounded = true;
        }
    }

    private void OnDrawGizmos()
    {

        if (isGrounded)
        {
            Gizmos.color = Color.cyan;
        }
        else
        {
            Gizmos.color = Color.magenta;
        }
        // draw a circle for the ground check
        Gizmos.DrawWireSphere(transform.position + groundCheckPosition, groundCheckRadius);

    }

    private void MovePlayer()
    {
        //process our horizontal movement
        // look at input
        float xValue = Input.GetAxis("Horizontal"); // -1, 0 , 1;

        animator.SetFloat("speed", rb.linearVelocityX);


        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && !facingRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            facingRight = true;
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && facingRight)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            facingRight = false;
        }

        // update the x velocity only;
        rb.linearVelocityX = xValue * speed;



        //jump
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            SoundManager.Instance.PlayJump();
            // make the player jump
            rb.linearVelocityY = jumpHeight;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Win"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("isWin"); // plays the win animation on the flag
            GameManager.Instance.ReachedEnd(); //set the gamestate to win

        }
        else if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Death")) //kills the player if hit enemy
        {

            if (GameManager.Instance.lives > 1)
            {
                transform.position = respawnPoint.position;
                GameObject.Find("Main Camera").transform.position = respawnPoint.position + new Vector3(7, 1, -3);
                GameManager.Instance.Respawn();
                GameManager.Instance.SubtractLives();
                SoundManager.Instance.PlayDeath();
            }
            else
            {
                SoundManager.Instance.PlayDeath();
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                GameManager.Instance.SubtractLives();
                Destroy(this.gameObject);
            }

        }
        
    }
    



}

