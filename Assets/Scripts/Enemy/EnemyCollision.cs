using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int damage = 3;
    public EnemyHealth _enemyHealth;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Sword"))
        {
            _enemyHealth.TakeDamage(damage);
        }
    }
}