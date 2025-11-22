using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float fireRate = 0.2f;
    [SerializeField] float projectileSpawnOffset = 0.5f;
    [SerializeField] bool isIa = false;

    public bool isFiring;
    Coroutine fireCoroutine;
    AudioManager audioManager;

    ObjectPool objectPool;

    void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        objectPool = GetComponent<ObjectPool>();
    }

    void Start()
    {
        isFiring = isIa;
    }

    void Update()
    {
        Fire();
    }


    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        } 
        else if (!isFiring && fireCoroutine != null) 
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject projectile;
            Vector3 spawnPosition = transform.position + transform.up * projectileSpawnOffset;

            if (objectPool != null)
            {
                projectile = objectPool.Get();
                projectile.transform.position = spawnPosition;
                projectile.transform.rotation = transform.rotation;
            }
            else
            {
                projectile = Instantiate(projectilePrefab, spawnPosition, transform.rotation);
                Destroy(projectile, projectileLifetime);
            }

            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            projectileRB.linearVelocity = (Vector2)(transform.up * projectileSpeed);

            audioManager.PlayShootingSFX();
            
            yield return new WaitForSeconds(fireRate);
        }
    }
}
