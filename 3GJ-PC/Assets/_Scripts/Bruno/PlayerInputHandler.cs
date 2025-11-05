using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
     private InputAction moveAction;
     private InputAction jumpAction;

    [SerializeField] private CharacterController characterController;
    [SerializeField] private CloneController cloneController;

    private Vector2 playerMoveDirection;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        jumpAction.performed += Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        //if (characterController.CoyoteTimeCounter > 0)
        //{

        //}
        animator.SetTrigger("isJumping");
        characterController.Jump();
        cloneController.Jump();
    }

    private void Start()
    {
        cloneController.cloneMoveDirection = -characterController.moveDirection;
    }

    private void Update()
    {
        playerMoveDirection = moveAction.ReadValue<Vector2>();
        characterController.PlayerMove(playerMoveDirection);
        cloneController.CloneMove(playerMoveDirection);
    }
}
