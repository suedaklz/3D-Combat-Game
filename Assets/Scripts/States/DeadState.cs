using System.Collections;
using UnityEngine;

public class DeadState : IState
{
    public DeadState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        characterManager.MonoBehaviourInstance.StartCoroutine(Dead());
    }

    public IEnumerator Dead()
    {
        characterManager.AnimatorInstance.SetBool("isDead", true);

        Debug.Log("playing dead Animation");
        AnimatorClipInfo[] stateInfo = characterManager.AnimatorInstance.GetCurrentAnimatorClipInfo(0);
        yield return new WaitForSeconds(stateInfo.Length);
        characterManager.AnimatorInstance.SetBool("isDead", false);
        GameObject.Destroy(characterManager.MonoBehaviourInstance.gameObject);
    }

    public override void OnUpdate() { }

    public override void OnExit() { }
}