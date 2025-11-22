using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteorPrefabs;
    [SerializeField] private float minSpawnDelay = 1.5f;
    [SerializeField] private float maxSpawnDelay = 3f;
    [SerializeField] private float minSpawnYOffset = 2f;
    [SerializeField] private float maxSpawnYOffset = 6f;
    [SerializeField] private float spawnRadius = 1f;
    [SerializeField] private int maxSpawnAttempts = 10;
    [SerializeField] private float minPlayerSpeed = 0.1f;

    private Camera mainCamera;
    private Coroutine spawnRoutine;
    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        mainCamera = Camera.main;
        PlayerController player = FindFirstObjectByType<PlayerController>();
        if (player != null)
        {
            playerRigidbody = player.GetComponent<Rigidbody2D>();
        }
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

            if (playerRigidbody != null && playerRigidbody.linearVelocity.magnitude > minPlayerSpeed)
            {
                SpawnMeteor();
            }
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
        Vector3 spawnPosition = Vector3.zero;
        bool validPositionFound = false;

        for (int i = 0; i < maxSpawnAttempts; i++)
        {
            spawnPosition = GetSpawnPosition();
            if (!Physics2D.OverlapCircle(spawnPosition, spawnRadius))
            {
                validPositionFound = true;
                break;
            }
        }

        if (validPositionFound)
        {
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetSpawnPosition()
    {
        if (mainCamera == null)
        {
            return transform.position;
        }

        float horizontalExtent = mainCamera.orthographicSize * mainCamera.aspect;
        float minX = mainCamera.transform.position.x - horizontalExtent;
        float maxX = mainCamera.transform.position.x + horizontalExtent;
        float x = Random.Range(minX, maxX);
        float randomYOffset = Random.Range(minSpawnYOffset, maxSpawnYOffset);
        float y = mainCamera.transform.position.y + mainCamera.orthographicSize + randomYOffset;
        
        return new Vector3(x, y, 0f);
    }
}