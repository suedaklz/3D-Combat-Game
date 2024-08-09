using UnityEngine;
using static UnityEditor.Progress;

public class PlayerCollision : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}