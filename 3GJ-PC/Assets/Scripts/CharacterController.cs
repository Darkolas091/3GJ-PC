using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D playerRigidbody2D;
    public Vector2 moveDirection;
    private bool hasJumped;

    private void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerRigidbody2D.linearVelocity = new Vector2(moveDirection.x * moveSpeed, playerRigidbody2D.linearVelocity.y);

        if (hasJumped)
        {
            playerRigidbody2D.linearVelocity = new Vector2(playerRigidbody2D.linearVelocity.x, jumpForce);
            hasJumped = false;
        }
    }

    public void PlayerMove(Vector2 currentPlayerMoveDirection)
    {
        moveDirection = currentPlayerMoveDirection;
    }

    public void Jump()
    {
        hasJumped = true;
    }
}
