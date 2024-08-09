using UnityEngine;

public class IdleState : IState
{

    public IdleState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter() { }

    public override void OnUpdate()
    {
        if (characterManager.RigidbodyInstance.velocity != Vector3.zero)
        {
            isComplete = true;
        }
    }

    public override void OnExit() { }
}