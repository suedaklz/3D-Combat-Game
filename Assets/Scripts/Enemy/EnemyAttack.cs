using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack: MonoBehaviour, IColliderManager
{
    public EnemyManager _enemyManager;
    public Collider weaponCollider;

    private float timer;

    public void SetColliderActive(bool isActive)
    {
        if (weaponCollider != null)
        {
            weaponCollider.enabled = isActive;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            timer = 0;
            if (_enemyManager.stateMachine.state == _enemyManager.walkState)
               _enemyManager.HandleAttackState();
        }
    }
}