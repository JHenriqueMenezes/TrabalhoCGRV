using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 4f;
    [SerializeField] private float destroyBelowY = -6f;

    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

        if (transform.position.y < destroyBelowY)
        {
            Destroy(gameObject);
        }
    }
}