using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawnerScriptFromDino : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public static float spawnInterval = 2f;
    private GameObject lastSpawnedPrefab;
    [SerializeField] private float minSpawnRange; // Диапазон появления препятствий "От"
    [SerializeField] private float maxSwapnRange; // Диапазон появления препятствий "До"


    private void Start()
    {
        // Запускаем спаун препятствий через указанный интервал
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            GameObject obstaclePrefab = GetRandomPrefabExpectLast();
            // Генерируем случайную позицию по оси Y для спауна препятствия
            float spawnX = Random.Range(minSpawnRange, maxSwapnRange);
            //int prefRand = Random.Range(0, obstaclePrefab.Length);
            // Создаем новый экземпляр препятствия в позиции, сгенерированной выше
            GameObject pfer = Instantiate(obstaclePrefab, new Vector3(spawnX, transform.position.y, 0), Quaternion.identity);
            Destroy(pfer, 5f);

            // Ждем указанный интервал перед следующим спауном
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
