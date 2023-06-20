using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public Transform spawnLineStart;
    public Transform spawnLineEnd;
    public float spawnIntervalMin = 1f;
    public float spawnIntervalMax = 3f;

    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnApple();
            ResetTimer();
        }
    }

    private void SpawnApple()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject apple = Instantiate(applePrefab, spawnPosition, Quaternion.identity);
        Destroy(apple, 10f); // Уничтожаем яблоко через 10 секунд (на случай, если оно не коснется земли)
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float spawnX = Random.Range(spawnLineStart.position.x, spawnLineEnd.position.x);
        float spawnY = transform.position.y;
        float spawnZ = transform.position.z;

        return new Vector3(spawnX, spawnY, spawnZ);
    }

    private void ResetTimer()
    {
        spawnTimer = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }
}



