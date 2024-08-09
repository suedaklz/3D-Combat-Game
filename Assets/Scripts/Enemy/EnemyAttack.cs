using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack: MonoBehaviour
{
    public EnemyManager _enemyManager;
    private float timer;

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