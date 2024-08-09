using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerManager playerManager;
    public HealthBar healthBar;

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

        if (health <= 0)
        {
            playerManager.HandleDeadState();
        }
        else
        {
            if (healthBar != null)
            {
                healthBar.SetHealth(health);
            }
            //_enemyManager.HandleHurtState();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}