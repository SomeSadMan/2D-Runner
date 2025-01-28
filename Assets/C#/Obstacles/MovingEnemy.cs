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
        
        
    }
}
