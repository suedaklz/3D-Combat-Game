using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyManager _enemyManager;
    public HealthBar healthBar;

    //private Animator _animator;

    public int maxHealth = 10;
    public int health;

    void Start()
    {
        health = maxHealth;

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(health);
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("enemy health: " + health);

        if (health <= 0)
        {
            _enemyManager.HandleDeadState();
        }
        else
        {
            if (healthBar != null)
            {
                healthBar.SetHealth(health);
            }
            _enemyManager.HandleHurtState();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
