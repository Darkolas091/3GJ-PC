using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    private InputAction moveAction;
    //private InputAction cloneMoveAction;
    private InputAction jumpAction;

    [SerializeField] private CharacterController characterController;
    [SerializeField] private CloneController cloneController;

    private Vector2 playerMoveDirection;
    //private Vector2 cloneMoveDirection;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        //moveAction = InputSystem.actions.FindAction("CloneMove");
        jumpAction = InputSystem.actions.FindAction("Jump");

        jumpAction.performed += Jump;

        characterController = GetComponent<CharacterController>();
        cloneController = GetComponent<CloneController>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        characterController.Jump();
    }
    private void Start()
    {
        cloneController.cloneMoveDirection = -characterController.moveDirection;
    }

    private void Update()
    {
        playerMoveDirection = moveAction.ReadValue<Vector2>();
        cloneController.cloneMoveDirection = moveAction.ReadValue<Vector2>();
        characterController.PlayerMove(playerMoveDirection);
        cloneController.CloneMove(-cloneController.cloneMoveDirection);

    }

}
