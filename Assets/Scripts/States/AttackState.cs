using System.Collections;
using UnityEngine;

public class AttackState : IState
{
    public AttackState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        characterManager.MonoBehaviourInstance.StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        characterManager.AnimatorInstance.SetBool("isAttack", true);
        AnimatorClipInfo[] stateInfo = characterManager.AnimatorInstance.GetCurrentAnimatorClipInfo(0);
        yield return new WaitForSeconds(stateInfo.Length);
        characterManager.AnimatorInstance.SetBool("isAttack", false);
        isComplete = true;

    }

    public override void OnUpdate() { }

    public override void OnExit() { }
}
