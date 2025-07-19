using Unity.VisualScripting;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int scoreAwarded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //if collision is with the player
        {
            // play a sound
            if (gameObject.name.Substring(0, 4).Equals("Coin"))
            {
                SoundManager.Instance.PlayCoin();
            }
            else if (gameObject.name.Substring(0, 6).Equals("Cherry"))
            {
                SoundManager.Instance.PlayCherry();
            }
            else if (gameObject.name.Substring(0, 6).Equals("Banana"))
            {
                SoundManager.Instance.PlayBanana();
                GameManager.Instance.DoublePoints(); //get double points when get banana

            }

            // add score
            GameManager.Instance.AddScore(scoreAwarded);

            //destroy
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
