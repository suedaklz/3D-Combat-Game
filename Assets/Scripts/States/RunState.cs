using System.Data;
using UnityEngine;

public class RunState : IState
{
    public RunState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        characterManager.AnimatorInstance.SetBool("isRun", true);
    }

    public override void OnUpdate() {}

    public override void OnExit()
    {
        characterManager.AnimatorInstance.SetBool("isRun", false);
    }
}