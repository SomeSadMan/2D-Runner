using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBeeSpeed();
        rb.velocity = Vector2.left * speed;
    }

    private void ChangeBeeSpeed()
    {
        if (PlatformController.speed == 4)
        {
            speed = 5f;
            
        }
        if (PlatformController.speed == 5)
        {
            speed = 6f;
        }
        if (PlatformController.speed == 6)
        {
            speed = 7f;

        }
        if (PlatformController.speed == 7)
        {
            speed = 8f;
        }
        if (PlatformController.speed == 8)
        {
            speed = 9f;

        }
        if (PlatformController.speed == 9)
        {
            speed = 10f;
        }
        if (PlatformController.speed == 10)
        {
            speed = 11f;

        }
        
    }
}
