using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstaclesPool : MonoBehaviour
{
    [SerializeField] private int poolSize;
    [SerializeField] private GameObject[] prefabs;
    private Queue<GameObject> obstaclePool = new Queue<GameObject>();
    private int _randomObstacle;

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstacle = Instantiate(prefabs[i]);
            obstaclePool.Enqueue(obstacle);
            obstacle.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetObstacle();
        }
    }

    public GameObject GetObstacle()
    {
        _randomObstacle = Random.Range(0, prefabs.Length);
        GameObject obstacle;
        if (obstaclePool.Count > 0)
        {
            obstacle = obstaclePool.Dequeue();
            obstacle.SetActive(true);
        }
        else
        {
            obstacle = Instantiate(prefabs[_randomObstacle]);
        }

        return obstacle;
    }

    public void ReturnObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);
        obstaclePool.Enqueue(obstacle);
    }
}
