using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            /*if (GameManager.Instance.lives > 0)
            {
                player.transform.position = respawnPoint.position;
                GameObject.Find("Main Camera").transform.position = respawnPoint.position + new Vector3(0, 0, -3);
                GameManager.Instance.Respawn();
                GameManager.Instance.SubtractLives();
            }
            else
            {*/ //to o fix this so that it properly revives and kills the player when eneded 
            Destroy(collision.gameObject);
            SoundManager.Instance.PlayDeath();
            GameManager.Instance.SubtractLives();
            //}

        }
    }
}
