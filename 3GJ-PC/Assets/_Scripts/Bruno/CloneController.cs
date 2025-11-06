using UnityEngine;

public class CloneController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Rigidbody2D cloneRigidbody2D;
    public Vector2 cloneMoveDirection;
    [SerializeField] private bool hasJumped;
    [SerializeField] private bool isGrounded;

    [SerializeField] private Animator animator;

    private void Start()
    {
        cloneRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    }

    private void FixedUpdate()
    {
        cloneRigidbody2D.linearVelocity = new Vector2(cloneMoveDirection.x * moveSpeed, cloneRigidbody2D.linearVelocity.y);

        if (hasJumped)
        {
            hasJumped = false;
            cloneRigidbody2D.linearVelocity = new Vector2(cloneRigidbody2D.linearVelocity.x, jumpForce);
        }
    }


    public void CloneMove(Vector2 currentPlayerMoveDirection)
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
            transform.localScale = new Vector2(1.5f, 1.5f);
        }
        else if (currentPlayerMoveDirection.x < 0)
        {
            transform.localScale = new Vector2(-1.5f, 1.5f);
        }
        cloneMoveDirection = new Vector2(-currentPlayerMoveDirection.x, currentPlayerMoveDirection.y);
    }


    public void Jump()
    {
        if (isGrounded)
        {
            hasJumped = true;
        }
    }
}
