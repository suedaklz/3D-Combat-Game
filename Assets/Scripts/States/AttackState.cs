using System.Collections;
using UnityEngine;

public class AttackState : IState
{
    private IColliderManager _colliderManager;

    public AttackState(ICharacterManager characterManager, IColliderManager colliderManager) : base(characterManager) {
        _colliderManager = colliderManager;
    }

    public override void OnEnter()
    {
        characterManager.MonoBehaviourInstance.StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        // Activate the collider
        _colliderManager.SetColliderActive(true);

        // Play attack animation
        characterManager.AnimatorInstance.SetBool("isAttack", true);
        AnimatorClipInfo[] stateInfo = characterManager.AnimatorInstance.GetCurrentAnimatorClipInfo(0);
        yield return new WaitForSeconds(stateInfo.Length); // Use clip length of the current animation

        // Deactivate the collider
        _colliderManager.SetColliderActive(false);
        characterManager.AnimatorInstance.SetBool("isAttack", false);
        isComplete = true;
    }

    public override void OnUpdate() { }

    public override void OnExit()
    {
        // Ensure the collider is disabled when exiting the attack state
        _colliderManager.SetColliderActive(false);
    }
}
