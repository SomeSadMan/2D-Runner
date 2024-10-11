using UnityEngine;
using UnityEngine.Pool;

public class PlatformPool : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;

    [SerializeField] private float currentXSpawnposition = 12f;

    public IObjectPool<GameObject> m_pool { get; set; }

    [SerializeField] private bool collectionChecks = true;

    [SerializeField] private int maxPoolSize = 15;

    void Start()
    {
        
    }

    
    void Update()
    {
        m_pool = new ObjectPool<GameObject>(CreatePlatform, OnTakeFromPool, OnReturnToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
    }

    public void SpawnPlatform()
    {
        m_pool.Get();
    }

    public void ReleasePlatform(GameObject platform)
    {
        m_pool.Release(platform);
    }

    private void OnDestroyPoolObject(GameObject platform)
    {
        Destroy(platform);
    }

    private void OnReturnToPool(GameObject platform)
    {
        platform.gameObject.SetActive(false);
    }

    private void OnTakeFromPool(GameObject platform)
    {
        platform.transform.position = new Vector3(currentXSpawnposition, 0, 0);
        platform.SetActive(true);
    }

    private GameObject CreatePlatform()
    {
        GameObject platform = Instantiate(platformPrefab, transform);
        platform.SetActive(false);

        return platform;
    }
}
