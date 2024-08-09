using System.Collections;
using UnityEngine;

public class AttackState : IState
{
    public AttackState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        characterManager.MonoBehaviourInstance.StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        characterManager.MonoBehaviourInstance.GetComponent<EquipmentSystem>().SetWeaponColliderActive(true);

        characterManager.AnimatorInstance.SetBool("isAttack", true);
        AnimatorClipInfo[] stateInfo = characterManager.AnimatorInstance.GetCurrentAnimatorClipInfo(0);
        yield return new WaitForSeconds(stateInfo.Length); 
        characterManager.MonoBehaviourInstance.GetComponent<EquipmentSystem>().SetWeaponColliderActive(false);
        characterManager.AnimatorInstance.SetBool("isAttack", false);
        isComplete = true;
    }

    public override void OnUpdate() { }

    public override void OnExit()
    {
        characterManager.MonoBehaviourInstance.GetComponent<EquipmentSystem>().SetWeaponColliderActive(false);
    }
}
