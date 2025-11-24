using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 0.5f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPosition;
    bool isShaking = false;

    public void Play()
    {
        if (!isShaking)
        {
            initialPosition = transform.position;
            StartCoroutine(ShakeCamera());
        }
    }

    IEnumerator ShakeCamera()
    {
        isShaking = true;
        float timeElapsed = 0;
        while (timeElapsed < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }  
        transform.position = initialPosition;
        isShaking = false;
    }
}
