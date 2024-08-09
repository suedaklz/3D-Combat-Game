using UnityEngine;

public abstract class IState
{
    public bool isComplete { get; protected set; }

    protected float startTime;
    public float time => Time.time - startTime;

    public ICharacterManager characterManager;

    public IState(ICharacterManager characterManager)
    {
        this.characterManager = characterManager;
    }

    public virtual void OnEnter() { }

    public virtual void OnUpdate() { }

    public virtual void OnExit()
    {
        isComplete = true;
    }

    public void Initialise()
    {
        isComplete = false;
        startTime = Time.time;
    }
}