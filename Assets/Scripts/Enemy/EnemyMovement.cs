using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;

    public Rigidbody rb;
    public Animator animator;

    public float speed = 2f;
    public float distanceBetween = 10f;

    public EnemyManager _enemyManager;
    private float _distance;
    private Vector3 _lastPosition;

    private void Awake()
    {
        _player = _enemyManager.player;
        _lastPosition = rb.position; // Initialize last position
    }

    void Update()
    {
        _distance = Vector3.Distance(transform.position, _player.transform.position);
        Vector3 direction = _player.transform.position - transform.position;

        if (_distance < distanceBetween)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(lookRotation);

            Vector3 newPosition = Vector3.MoveTowards(rb.position, _player.transform.position, Time.deltaTime * speed);
            Vector3 velocity = (newPosition - _lastPosition) / Time.deltaTime;

            rb.MovePosition(newPosition);
            _lastPosition = newPosition; // Update _lastPosition after velocity calculation

            Debug.Log("Enemy velocity: " + velocity);

            if ((Math.Abs(velocity.x) > 0 || Math.Abs(velocity.z) > 0))
            {
                _enemyManager.HandleWalkState(velocity);
                Debug.Log("Enemy: Handle walk state.");
            }
        }
        else
        {
            _enemyManager.HandleIdleState();
        }
    }
}
