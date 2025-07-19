using System.Threading;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    public int points;
    public GameObject fireball;
    public Transform firePos;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(fireball, firePos.position, Quaternion.identity);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //destroy the enemy
            SoundManager.Instance.PlayKill();
            //prevent this object from collliding with player 
            //gameObject.layer = 13; // 13 is enemy dead
            gameObject.layer = LayerMask.NameToLayer("Dead");
            //give gamemanager points
            GameManager.Instance.AddScore(points);
            //play soundx
            //visually mark the enemy dead -- animation, flash , change color   
            GetComponent<Animator>().SetTrigger("death");

            //destroy this object in time        
            Destroy(gameObject, 1f);
        }

    }
}
