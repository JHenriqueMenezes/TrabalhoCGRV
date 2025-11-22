using UnityEngine;

public class TimePowerUp : MonoBehaviour
{
    [SerializeField] float timeToAdd = 20f;
    [SerializeField] int healthToAdd = 15;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameWinCondition gameWinCondition = FindFirstObjectByType<GameWinCondition>();
            if (gameWinCondition != null)
            {
                gameWinCondition.AddTime(timeToAdd);
            }

            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healthToAdd);
            }

            Destroy(gameObject);
        }
    }
}
