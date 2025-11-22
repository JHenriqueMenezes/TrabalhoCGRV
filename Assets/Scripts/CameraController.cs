using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;

    void LateUpdate()
    {
        if (player != null && player.position.y > transform.position.y)
        {
            transform.position = new Vector3(
                transform.position.x,
                player.position.y,
                transform.position.z
            );
        }
    }
}
