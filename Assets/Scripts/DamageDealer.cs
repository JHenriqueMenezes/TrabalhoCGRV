using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        if (GetComponent<Projectile>() != null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
