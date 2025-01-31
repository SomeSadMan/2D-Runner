using UnityEngine;


public class Coin : MonoBehaviour
{
    private readonly int coinValue = 1;
    private Rigidbody2D _rigidbody2D;
    private GameManager gameManager;
    public Coinspool CoinsPool { get; set; }
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = Vector2.left * 3;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
           AddCoinValue();
           CoinsPool.ReturnCoin(gameObject);
        }
    }

    public void AddCoinValue()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.СoinsScore += coinValue;
    }

    
}


