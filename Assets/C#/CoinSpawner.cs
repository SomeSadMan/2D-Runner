using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    private float positionX;
    private float randomPositionY;
    private Vector2 spawnPosition;
    private float spawnDelay;

    private void CoinSpawn()
    {
       // positionX = //TODO должна быть равна какой либо позиции платформы 
       randomPositionY = Random.Range(-4, -1);
       spawnPosition = new Vector2(positionX, randomPositionY);
       GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
       Destroy(coin, 5f);

    }

}
