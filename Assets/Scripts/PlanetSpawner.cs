using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField] Sprite[] planetSprites;
    [SerializeField] float minSpawnDelay = 5f;
    [SerializeField] float maxSpawnDelay = 15f;
    [SerializeField] float spawnYOffset = 15f; 
    [SerializeField] int sortingOrder = -1;
    [SerializeField] float minSpawnDistance = 10f; 

    Camera mainCamera;
    Queue<Sprite> spawnQueue = new Queue<Sprite>();
    List<GameObject> activePlanets = new List<GameObject>();

    void Start()
    {
        mainCamera = Camera.main;
        FillQueue();
        StartCoroutine(SpawnLoop());
    }

    void FillQueue()
    {
        List<Sprite> shuffled = new List<Sprite>(planetSprites);
        for (int i = 0; i < shuffled.Count; i++)
        {
            Sprite temp = shuffled[i];
            int randomIndex = Random.Range(i, shuffled.Count);
            shuffled[i] = shuffled[randomIndex];
            shuffled[randomIndex] = temp;
        }

        foreach (Sprite s in shuffled)
        {
            spawnQueue.Enqueue(s);
        }
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            TrySpawnPlanet();
        }
    }

    void TrySpawnPlanet()
    {
        if (planetSprites.Length == 0) return;

        activePlanets.RemoveAll(item => item == null);

        if (spawnQueue.Count == 0)
        {
            FillQueue();
        }

        Vector3 spawnPos = Vector3.zero;
        bool validPosition = false;
        int attempts = 10;

        if (mainCamera != null)
        {
            float height = mainCamera.orthographicSize;
            float width = height * mainCamera.aspect;
            float spawnY = mainCamera.transform.position.y + height + spawnYOffset;
            float minX = mainCamera.transform.position.x - width;
            float maxX = mainCamera.transform.position.x + width;

            for (int i = 0; i < attempts; i++)
            {
                float randomX = Random.Range(minX, maxX);
                Vector3 candidatePos = new Vector3(randomX, spawnY, 0);

                if (IsPositionValid(candidatePos))
                {
                    spawnPos = candidatePos;
                    validPosition = true;
                    break;
                }
            }
        }

        if (validPosition)
        {
            SpawnPlanet(spawnPos);
        }
    }

    bool IsPositionValid(Vector3 position)
    {
        foreach (GameObject planet in activePlanets)
        {
            if (planet != null)
            {
                if (Vector3.Distance(position, planet.transform.position) < minSpawnDistance)
                {
                    return false;
                }
            }
        }
        return true;
    }

    void SpawnPlanet(Vector3 position)
    {
        Sprite spriteToSpawn = spawnQueue.Dequeue();

        GameObject planet = new GameObject("Planet");
        SpriteRenderer sr = planet.AddComponent<SpriteRenderer>();
        sr.sprite = spriteToSpawn;
        sr.sortingOrder = sortingOrder;

        planet.AddComponent<PlanetMover>();
        planet.transform.position = position;

        float randomScale = Random.Range(0.5f, 1.5f);
        planet.transform.localScale = new Vector3(randomScale, randomScale, 1);

        activePlanets.Add(planet);
    }
}
