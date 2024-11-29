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
    
    


    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            gameManager = FindObjectOfType<GameManager>();
            gameManager.Coins += coinValue;
            Destroy(gameObject);
        }
    }

    
}


