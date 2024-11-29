using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour 
//TODO - придумать или понять , как я хочу чтобы работал новый спавнер, так как сейчас я проболем не вижу и идей тоже никаких нет
{
    [Header("Obstacles Spawn")]
    public List<GameObject> obstaclePrefabs;
    internal float obstacleSpawnDelay = 2f;
    private GameObject lastSpawnedPrefab;
    [SerializeField] private float minSpawnRange;
    [SerializeField] private float maxSwapnRange;
    
    [Header("Coin Spawn")]
    [SerializeField] private GameObject coinPrefab;
    private float positionX;
    private float randomPositionY;
    private Vector2 spawnPosition;
    private float coinSpawnDelay = 6f;
    private float nextSpawnTime = 0f;


    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private void Update()
    {
        CoinSpawn();
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            GameObject obstaclePrefab = GetRandomPrefabExpectLast();
            float spawnX = Random.Range(minSpawnRange, maxSwapnRange);
            GameObject pref = Instantiate(obstaclePrefab, new Vector3(spawnX, transform.position.y, 0), Quaternion.identity);
            Destroy(pref, 5f);
            yield return new WaitForSeconds(obstacleSpawnDelay);
        }
    }

     GameObject GetRandomPrefabExpectLast()
     {
        if (obstaclePrefabs.Count == 0)
        {
            return null;
        }
        if(lastSpawnedPrefab == null)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Count);
            lastSpawnedPrefab = obstaclePrefabs[randomIndex];
            return lastSpawnedPrefab;
        }

        GameObject newPrefab = lastSpawnedPrefab;
        
        while (newPrefab == lastSpawnedPrefab)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Count);
            newPrefab = obstaclePrefabs[randomIndex];
        }
        lastSpawnedPrefab = newPrefab;
        return newPrefab;
     }
     
     private void CoinSpawn()
     {
         if (Time.time > nextSpawnTime)
         {
             nextSpawnTime = Time.time + coinSpawnDelay;
             
             // positionX = //TODO должна быть равна какой либо позиции платформы 
             positionX = Random.Range( 3, 5);
             
             randomPositionY = Random.Range(-4, 0);
             spawnPosition = new Vector2(positionX, randomPositionY);
             GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
             Destroy(coin, 5f);
         }
       

     }
}
