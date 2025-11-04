using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D playerRigidbody2D;
    public Vector2 moveDirection;
    public float coyoteTime = 0.2f;
    //private float coyoteTimeCounter;
    //public float CoyoteTimeCounter => coyoteTimeCounter;
    private bool hasJumped;
    private bool isGrounded;

    private void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void FixedUpdate()
    {
        playerRigidbody2D.linearVelocity = new Vector2(moveDirection.x * moveSpeed, playerRigidbody2D.linearVelocity.y);

        if (hasJumped)
        {
            hasJumped = false;
            playerRigidbody2D.linearVelocity = new Vector2(playerRigidbody2D.linearVelocity.x, jumpForce);
        }
    }

    public void PlayerMove(Vector2 currentPlayerMoveDirection)
    {
        moveDirection = currentPlayerMoveDirection;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            //coyoteTimeCounter = coyoteTime;
            hasJumped = true;
        }
        //else
        //{
        //    coyoteTimeCounter -= Time.deltaTime;
        //}
    }
}
