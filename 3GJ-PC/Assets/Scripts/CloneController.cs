using UnityEngine;

public class CloneController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D cloneRigidbody2D;
    [HideInInspector] public Vector2 cloneMoveDirection;
    private bool hasJumped;

    private void Start()
    {
        cloneRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        cloneRigidbody2D.linearVelocity = new Vector2(cloneMoveDirection.x * moveSpeed, cloneRigidbody2D.linearVelocity.y);

        if (hasJumped)
        {
            cloneRigidbody2D.linearVelocity = new Vector2(cloneRigidbody2D.linearVelocity.x, jumpForce);
            hasJumped = false;
        }
    }


    public void CloneMove(Vector2 currentPlayerMoveDirection)
    {
        cloneMoveDirection = new Vector2(-currentPlayerMoveDirection.x, currentPlayerMoveDirection.y);
    }


    public void Jump()
    {
        hasJumped = true;
    }
}
