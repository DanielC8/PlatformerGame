using UnityEngine;

public class FireballScript : MonoBehaviour
{

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityX = -2;
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
