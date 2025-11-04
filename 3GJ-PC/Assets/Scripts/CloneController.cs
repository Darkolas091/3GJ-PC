using UnityEngine;

public class CloneController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D cloneRigidbody2D;
    [HideInInspector] public Vector2 cloneMoveDirection;
    private bool hasJumped;

    private CharacterController characterController;

    private void Start()
    {
        cloneRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        cloneRigidbody2D.linearVelocityX = -characterController.moveDirection.x * moveSpeed;

        if (hasJumped)
        {
            cloneRigidbody2D.linearVelocityY = jumpForce;
            hasJumped = false;
        }
    }


    public void CloneMove(Vector2 currentPlayerMoveDirection)
    {
        cloneMoveDirection = -currentPlayerMoveDirection;
    }


    public void Jump()
    {
        hasJumped = true;
    }
}
