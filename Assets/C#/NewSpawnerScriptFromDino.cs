using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawnerScriptFromDino : MonoBehaviour 
//TODO - придумать или понять , как я хочу чтобы работал новый спавнер, так как сейчас я проболем не вижу и идей тоже никаких нет
{
    public List<GameObject> obstaclePrefabs;
    internal float spawnInterval = 2f;
    private GameObject lastSpawnedPrefab;
    [SerializeField] private float minSpawnRange;
    [SerializeField] private float maxSwapnRange;


    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            GameObject obstaclePrefab = GetRandomPrefabExpectLast();
            float spawnX = Random.Range(minSpawnRange, maxSwapnRange);
            GameObject pfer = Instantiate(obstaclePrefab, new Vector3(spawnX, transform.position.y, 0), Quaternion.identity);
            Destroy(pfer, 5f);
            yield return new WaitForSeconds(spawnInterval);
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
}
