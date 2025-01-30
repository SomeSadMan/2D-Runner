using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstaclesPool : MonoBehaviour
{
    [SerializeField] private int poolSize;
    [SerializeField] private GameObject[] prefabs;
    private List<GameObject> obstaclePool = new List<GameObject>();
    private int randomObstacle;
    private int randomIndex;
    [SerializeField] private Player player;

    private void Start()
    {
        player.OnReturnInPool += ReturnObstacle;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstacle = Instantiate(prefabs[i % prefabs.Length], transform);
            obstacle.SetActive(false);
            obstaclePool.Add(obstacle);
        }
    }
    

    public GameObject GetObstacle()
    {
        List<GameObject> inactives = new List<GameObject>();

        foreach (var obstacle in obstaclePool)
        {
            if (!obstacle.activeInHierarchy)
            {
                inactives.Add(obstacle);
                
            }
        }

        if (inactives.Count > 0)
        {
            int _randomIndex = Random.Range(0, inactives.Count);
            GameObject randObstacle = inactives[_randomIndex];
            randObstacle.SetActive(true);
            return randObstacle;
        }
        
        int randomIndexPref = Random.Range(0, prefabs.Length);
        GameObject newObstacle = Instantiate(prefabs[randomIndexPref], transform);
        obstaclePool.Add(newObstacle);
        return newObstacle;
    }

    public void ReturnObstacle( GameObject obstacle)
    {
        obstacle.SetActive(false);
    }
}
