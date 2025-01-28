using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinspool : MonoBehaviour
{
    [SerializeField] private int poolSize;
    [SerializeField] private GameObject prefab;
    private Queue<GameObject> coinPool = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject coin = Instantiate(prefab);
            coinPool.Enqueue(coin);
            coin.SetActive(false);
        }
    }
}
