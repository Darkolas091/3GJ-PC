using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Rigidbody2D playerRigidbody2D;
    public Vector2 moveDirection;
    [SerializeField] private float coyoteTime = 0.2f;
    //[SerializeField] private float coyoteTimeCounter;
    //[SerializeField] private float CoyoteTimeCounter => coyoteTimeCounter;
    [SerializeField] private bool hasJumped;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Animator animator;

    private void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        if (currentPlayerMoveDirection.magnitude > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {

            animator.SetBool("isMoving", false);

        }

        if (currentPlayerMoveDirection.x > 0)
        {
            transform.localScale = new Vector2(-5, 5);
        }
        else if(currentPlayerMoveDirection.x < 0)
        {
            transform.localScale = new Vector2(5,5);
        }
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
