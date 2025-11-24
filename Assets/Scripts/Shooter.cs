using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float fireRate = 0.2f;
    [SerializeField] float projectileSpawnOffset = 0.5f;

    public bool isFiring;
    Coroutine fireCoroutine;
    AudioManager audioManager;

    void Update()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
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
            Vector3 spawnPosition = transform.position + transform.up * projectileSpawnOffset;
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, transform.rotation);

            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            projectileRB.linearVelocity = (Vector2)(transform.up * projectileSpeed);

            Destroy(projectile, projectileLifetime);

            audioManager.PlayShootingSFX();
            
            yield return new WaitForSeconds(fireRate);
        }
    }
}

