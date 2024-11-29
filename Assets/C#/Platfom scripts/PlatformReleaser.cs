using UnityEngine;

public class PlatformReleaser : MonoBehaviour
{
    [SerializeField] private PlatformPool platformPool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            platformPool.ReleasePlatform(collision.gameObject);
            platformPool.SpawnPlatform();
        }
    }
}
