using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour, ICharacterManager
{
    internal IdleState idleState;
    internal WalkState walkState;
    internal RunState runState;
    //internal HurtState hurtState;
    //internal DeadState deadState;
    internal CombatState combatState;
    internal AttackState attackState;
    internal StateMachine stateMachine;
    public static PlayerManager instance;
    public PlayerMovement playerMovement;

    ICharacterManager playerManager = PlayerManager.instance;

    public Animator AnimatorInstance => playerMovement.animator;
    public Rigidbody RigidbodyInstance => playerMovement.rb;
    public MonoBehaviour MonoBehaviourInstance => this;

    void Awake()
    {
        playerManager = this;
        instance = this;

        stateMachine = new StateMachine();

        idleState = new IdleState(playerManager);
        walkState = new WalkState(playerManager);
        runState = new RunState(playerManager);
        //deadState = new DeadState(playerManager);
        attackState = new AttackState(playerManager);
        combatState = new CombatState(playerManager);
        //hurtState = new HurtState(playerManager);

        stateMachine.Set(idleState);
    }

    private void Update()
    {
        stateMachine.state?.OnUpdate();
    }

    public void SelectState(Vector3 moveDirection)
    {    
        if (moveDirection.magnitude > 0)
        {
            if (playerMovement.animator.GetBool("isAttack") == false &&
                playerMovement.animator.GetBool("isDead") == false)
                stateMachine.Set(walkState);
        }
        else
        {
            if (playerMovement.animator.GetBool("isAttack") == false &&
                playerMovement.animator.GetBool("isDead") == false)
                stateMachine.Set(idleState);
        }
    }

    public void HandleRunState()
    {
        if (playerMovement.animator.GetBool("isDead") == false)
            stateMachine.Set(runState);
    }

    //public void HandleHurtState()
    //{
    //    if (kachujinMovement.animator.GetBool("isDead") == false)
    //        stateMachine.Set(hurtState);
    //}

    //public void HandleDeadState()
    //{
    //    stateMachine.Set(deadState);
    //}

    public void HandleAttackState()
    {
        Debug.Log("Set state attack state");

        if (playerMovement.animator.GetBool("isDead") == false)
            stateMachine.Set(attackState);
    }

    public void HandleCombatState()
    {
        if (playerMovement.animator.GetBool("isDead") == false)
            stateMachine.Set(combatState);
    }
}
