using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float zigzagAmplitude = 0f;
    [SerializeField] private float zigzagFrequency = 1f;
    [SerializeField] private float destroyBelowY = -6f;

    private float baseX;
    private float zigzagTimer;

    private void OnEnable()
    {
        baseX = transform.position.x;
        zigzagTimer = 0f;
    }

    private void Update()
    {
        zigzagTimer += Time.deltaTime;

        Vector3 position = transform.position;
        position += Vector3.down * moveSpeed * Time.deltaTime;

        if (!Mathf.Approximately(zigzagAmplitude, 0f))
        {
            float offset = Mathf.Sin(zigzagTimer * zigzagFrequency) * zigzagAmplitude;
            position.x = baseX + offset;
        }
        else
        {
            baseX = position.x;
        }

        transform.position = position;

        if (position.y < destroyBelowY)
        {
            Destroy(gameObject);
        }
    }
}
