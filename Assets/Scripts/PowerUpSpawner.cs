using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] int maxSpawns = 3;
    [SerializeField] float minSpawnDelay = 10f;
    [SerializeField] float maxSpawnDelay = 20f;
    [SerializeField] float verticalSpawnOffset = 1f;

    private int spawnCount = 0;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (spawnCount < maxSpawns)
        {
            float waitTime = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(waitTime);

            if (spawnCount < maxSpawns)
            {
                SpawnPowerUp();
            }
        }
    }

    void SpawnPowerUp()
    {
        if (powerUpPrefab == null) return;

        Vector3 spawnPosition = GetSpawnPosition();
        Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
        spawnCount++;
    }

    Vector3 GetSpawnPosition()
    {
        if (mainCamera == null) return transform.position;

        float horizontalExtent = mainCamera.orthographicSize * mainCamera.aspect;
        float minX = mainCamera.transform.position.x - horizontalExtent + 1f; 
        float maxX = mainCamera.transform.position.x + horizontalExtent - 1f; 
        
        float x = Random.Range(minX, maxX);
        float y = mainCamera.transform.position.y + mainCamera.orthographicSize + verticalSpawnOffset;

        return new Vector3(x, y, 0);
    }
}
