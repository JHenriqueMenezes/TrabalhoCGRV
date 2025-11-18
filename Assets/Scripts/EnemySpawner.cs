using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float minSpawnDelay = 2f;
    [SerializeField] private float maxSpawnDelay = 4f;
    [SerializeField] private float verticalSpawnOffset = 1f;

    private Camera mainCamera;
    private Coroutine spawnRoutine;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        if (spawnRoutine == null)
        {
            spawnRoutine = StartCoroutine(SpawnLoop());
        }
    }

    private void OnDisable()
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
            spawnRoutine = null;
        }
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetRandomDelay());
            SpawnEnemy();
        }
    }

    private float GetRandomDelay()
    {
        float min = Mathf.Max(0f, Mathf.Min(minSpawnDelay, maxSpawnDelay));
        float max = Mathf.Max(minSpawnDelay, maxSpawnDelay);

        if (Mathf.Approximately(min, max))
        {
            return max;
        }

        return Random.Range(min, max);
    }

    private void SpawnEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0)
        {
            return;
        }

        Vector3 position = GetSpawnPosition();
        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(prefab, position, Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        if (mainCamera == null)
        {
            return transform.position;
        }

        float halfHeight = mainCamera.orthographicSize;
        float halfWidth = halfHeight * mainCamera.aspect;
        float minX = mainCamera.transform.position.x - halfWidth;
        float maxX = mainCamera.transform.position.x + halfWidth;
        float x = Random.Range(minX, maxX);
        float y = mainCamera.transform.position.y + halfHeight + verticalSpawnOffset;
        return new Vector3(x, y, 0f);
    }
}