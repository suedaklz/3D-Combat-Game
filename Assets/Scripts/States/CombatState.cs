using System.Collections;
using UnityEngine;

public class CombatState : IState
{
    public CombatState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        characterManager.MonoBehaviourInstance.StartCoroutine(Combat());
    }

    public IEnumerator Combat()
    {
        characterManager.AnimatorInstance.SetBool("isCombat", true);

        AnimatorClipInfo[] stateInfo = characterManager.AnimatorInstance.GetCurrentAnimatorClipInfo(0);
        yield return new WaitForSeconds(stateInfo.Length);
        characterManager.AnimatorInstance.SetBool("isCombat", false);
        isComplete = true;
    }

    public override void OnUpdate() { }

    public override void OnExit() { }
}
