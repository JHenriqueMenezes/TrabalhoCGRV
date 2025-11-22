using UnityEngine;

public class PlanetMover : MonoBehaviour
{
    [SerializeField] float minSpeed = 0.5f;
    [SerializeField] float maxSpeed = 2f;

    float speed;
    Camera mainCamera;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        mainCamera = Camera.main;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (mainCamera != null)
        {
            float bottomEdge = mainCamera.transform.position.y - mainCamera.orthographicSize;
            if (transform.position.y < bottomEdge - 5f) 
            {
                Destroy(gameObject);
            }
        }
    }
}
