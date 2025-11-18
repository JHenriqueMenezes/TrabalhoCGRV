using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteorPrefabs;
    [SerializeField] private float minSpawnDelay = 1.5f;
    [SerializeField] private float maxSpawnDelay = 3f;
    [SerializeField] private float verticalSpawnOffset = 1f;

    private Camera mainCamera;
    private Coroutine spawnRoutine;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        spawnRoutine = StartCoroutine(SpawnLoop());
    }

    private void OnDisable()
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
        }
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            float waitTime = GetRandomDelay();
            yield return new WaitForSeconds(waitTime);
            SpawnMeteor();
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

    private void SpawnMeteor()
    {
        if (meteorPrefabs == null || meteorPrefabs.Length == 0)
        {
            return;
        }

        GameObject prefab = meteorPrefabs[Random.Range(0, meteorPrefabs.Length)];
        Vector3 spawnPosition = GetSpawnPosition();
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        if (mainCamera == null)
        {
            return transform.position;
        }

        float horizontalExtent = mainCamera.orthographicSize * mainCamera.aspect;
        float x = Random.Range(-horizontalExtent, horizontalExtent);
        float y = mainCamera.transform.position.y + mainCamera.orthographicSize + verticalSpawnOffset;
        return new Vector3(x, y, 0f);
    }
}