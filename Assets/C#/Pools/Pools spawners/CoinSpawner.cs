using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coinspool coinPool;
    [SerializeField] private Transform[] coinPosition;
    [SerializeField] private float delay;
    private int randomPosition;

    private IEnumerator SpawnCoinsAfterTime(float time)
    {
        while (true)
        {
            randomPosition = Random.Range(0, coinPosition.Length);
            GameObject coin = coinPool.GetCoin();
            coin.transform.position = coinPosition[randomPosition].position;
            yield return new WaitForSeconds(time);
        }
    }
    void Start()
    {
        StartCoroutine(SpawnCoinsAfterTime(delay));
    }

   
}
