using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerManager playerManager;

    public int maxHealth = 10;
    public int health;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            //playerManager.HandleDeadState();
        }
        else
        {
            //playerManager.HandleHurtState();
        }
    }
}