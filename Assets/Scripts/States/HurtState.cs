using System.Collections;
using UnityEngine;

public class HurtState : IState
{
    public HurtState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        characterManager.MonoBehaviourInstance.StartCoroutine(Hurt());
    }

    public IEnumerator Hurt()
    {
        characterManager.AnimatorInstance.SetBool("isHurt", true);

        AnimatorClipInfo[] stateInfo = characterManager.AnimatorInstance.GetCurrentAnimatorClipInfo(0);
        yield return new WaitForSeconds(stateInfo.Length);
        characterManager.AnimatorInstance.SetBool("isHurt", false);
    }

    public override void OnUpdate() { }

    public override void OnExit() { }
}