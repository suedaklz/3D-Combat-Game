using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int damage = 3;
    public EnemyHealth _enemyHealth;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Sword"))
        {
            Debug.Log("enemy + sword collision");
            _enemyHealth.TakeDamage(damage);
        }
    }
}