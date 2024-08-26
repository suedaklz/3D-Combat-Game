using System.Collections;
using UnityEngine;

public class DefendState : IState
{
    public DefendState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        characterManager.MonoBehaviourInstance.StartCoroutine(Defend());
    }

    public IEnumerator Defend()
    {
        characterManager.AnimatorInstance.SetBool("isDefend", true);

        AnimatorClipInfo[] stateInfo = characterManager.AnimatorInstance.GetCurrentAnimatorClipInfo(0);
        yield return new WaitForSeconds(stateInfo.Length);
        characterManager.AnimatorInstance.SetBool("isDefend", false);
    }

    public override void OnUpdate() { }

    public override void OnExit() { }
}