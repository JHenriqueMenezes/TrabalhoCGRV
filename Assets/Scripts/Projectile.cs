using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifetime = 5f;

    void OnEnable()
    {
        StartCoroutine(DisableAfterTime());
    }

    IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}
