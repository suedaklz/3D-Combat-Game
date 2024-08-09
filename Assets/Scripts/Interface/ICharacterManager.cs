using UnityEngine;

public interface ICharacterManager
{
    Animator AnimatorInstance { get; }
    Rigidbody RigidbodyInstance { get; }
    MonoBehaviour MonoBehaviourInstance { get; }
}
