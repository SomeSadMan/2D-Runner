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
        GameObject coin;
        if (coinPool.Count > 0)
        {
            coin = coinPool.Dequeue();
        }
        else
        {
            coin = Instantiate(prefab, transform);
            
        }
        
        coin.SetActive(true);
        Coin coinScr = coin.GetComponent<Coin>();
        if (coinScr != null)
        {
            coinScr.CoinsPool = this;
        }
        
        return coin;
    }

    public void ReturnCoin(GameObject coin)
    {
        coinPool.Enqueue(coin);
        coin.SetActive(false);
    }
}
