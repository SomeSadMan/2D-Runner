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
            GameObject coin = Instantiate(prefab, transform);
            coinPool.Enqueue(coin);
            coin.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetCoin();
        }
    }

    public GameObject GetCoin()
    {
        if (coinPool.Count > 0)
        {
            GameObject coin = coinPool.Dequeue();
            coin.SetActive(true);
            return coin;
        }

        GameObject newCoin = Instantiate(prefab, transform);
        return newCoin;
    }

    public void ReturnCoin(GameObject coin)
    {
        coinPool.Enqueue(coin);
        coin.SetActive(false);
    }
}
