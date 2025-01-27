using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ObstaclesPool pool;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval;
    void Start()
    {
        StartCoroutine(ActivateInterval());
    }

    private IEnumerator ActivateInterval()
    {
        while (true)
        {
            GameObject obstacle = pool.GetObstacle();
            obstacle.transform.position = spawnPoint.position;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

}
