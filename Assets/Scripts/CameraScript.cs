using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;

    private float xVelocity = 0f;
    private float yVelocity = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    {
        player = GameObject.Find("Player");
    }

    // fixed Update to moe the camera smooothly with the player
    void FixedUpdate()
    {
        if (player)
        {
            Vector3 thisPos = transform.position;
            Vector3 playerPos = player.transform.position;
            if (playerPos.x > thisPos.x + 0.01f)
            {
                thisPos.x = Mathf.SmoothDamp(thisPos.x, playerPos.x, ref xVelocity, 0.5f);
                transform.position = thisPos;
            }          
        }

        
    }
}
