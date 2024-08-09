using System.Data;
using UnityEngine;

public class WalkState : IState
{
    public WalkState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        characterManager.AnimatorInstance.SetBool("isWalk", true);
    }

    public override void OnUpdate()
    {
        float velocityX = characterManager.RigidbodyInstance.velocity.x;
        float velocityZ = characterManager.RigidbodyInstance.velocity.z;

        if (Mathf.Abs(velocityX) < 0.1f || Mathf.Abs(velocityZ) < 0.1f)
        {
            isComplete = true;
        }
    }

    public override void OnExit()
    {
        characterManager.AnimatorInstance.SetBool("isWalk", false);
    }
}