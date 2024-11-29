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
    [SerializeField] private Transform platform;
    private float startCoinPositionX;


    private void Start()
    {
        
        if (platform != null)
        {
            startCoinPositionX = transform.position.x - platform.position.x;
        }
    }

    private void Update()
    {
        
        if (platform != null)
        {
            transform.position = new Vector3(platform.position.x + startCoinPositionX, transform.position.y,
                transform.position.z);
        }
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


