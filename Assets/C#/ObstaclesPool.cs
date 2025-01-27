using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstaclesPool : MonoBehaviour
{
    [SerializeField] private int poolSize;
    [SerializeField] private GameObject[] prefabs;
    private Queue<GameObject> obstaclePool = new Queue<GameObject>();
    private int randomObstacle;

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstacle = Instantiate(prefabs[i]);
            obstaclePool.Enqueue(obstacle);
            obstacle.SetActive(false);
        }
    }
    

    public GameObject GetObstacle()
    {
        randomObstacle = Random.Range(0, prefabs.Length);
        GameObject obstacle;
        if (obstaclePool.Count > 0)
        {
            obstacle = obstaclePool.Dequeue();
            obstacle.SetActive(true);
        }
        else
        {
            obstacle = Instantiate(prefabs[randomObstacle]);
        }

        return obstacle;
    }

    public void ReturnObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);
        obstaclePool.Enqueue(obstacle);
    }
}
