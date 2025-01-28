using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Coin : MonoBehaviour
{
    private GameManager gameManager;
    private readonly int coinValue = 1;
    private Rigidbody2D _rigidbody2D;
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
        if (coll.CompareTag("PlayerOld"))
        {
            gameManager = FindObjectOfType<GameManager>();
            gameManager.Coins += coinValue;
            //Destroy(gameObject);
            Debug.Log("Монетка собрана, возвращаем в пул.");
            CoinsPool.ReturnCoin(gameObject);
        }
    }

    
}


