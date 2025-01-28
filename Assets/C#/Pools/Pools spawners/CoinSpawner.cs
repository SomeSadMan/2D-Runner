using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coinspool coinPool;
    [SerializeField] private Transform coinPosition;
    [SerializeField] private float delay;

    private IEnumerator SpawnCoinsAfterTime(float time)
    {
        GameObject coin = coinPool.GetCoin();
        coin.transform.position = coinPosition.position;
        yield return new WaitForSeconds(time);
    }
    void Start()
    {
        StartCoroutine(SpawnCoinsAfterTime(delay));
    }

   
}
