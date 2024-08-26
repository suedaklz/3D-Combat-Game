using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Default walk speed
    public float runSpeed = 10f;  // Run speed

    public Transform mainCamera;
    public Rigidbody rb;
    public Animator animator;

    public float xInput { get; private set; }
    public float zInput { get; private set; }

    private PlayerManager _playerManager;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    bool inCombatState = false;

    private void Start()
    {
        _playerManager = PlayerManager.instance;
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        
        Vector3 moveDirection = new Vector3(xInput, 0, zInput).normalized ;
        Vector3 moveDir = CheckDirection(moveDirection) * moveSpeed ;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _playerManager.HandleCombatState(); //combat state
            inCombatState = !inCombatState;
            Debug.Log("in combat state : " + inCombatState);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (inCombatState)
            {
                _playerManager.HandleAttackState(); //attack state
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (inCombatState)
            {
                _playerManager.HandleDefendState();
            }
        }

        if ((Math.Abs(xInput) > 0 || Math.Abs(zInput) > 0))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {

                moveDirection = new Vector3(xInput, 0, zInput).normalized ;
                moveDir = CheckDirection(moveDirection) * runSpeed;
                rb.velocity = moveDir;
                _playerManager.HandleRunState(); //run state
            }
            else
            {
                rb.velocity = moveDir;
                _playerManager.SelectState(moveDir); //walk state
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            _playerManager.SelectState(Vector3.zero); //idle state
        }     
    }

    public Vector3 CheckDirection(Vector3 moveDirection)
    {
        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        return moveDir;
    }
}