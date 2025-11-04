using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D playerRigidbody2D;
     public Vector2 moveDirection;
    private bool hasJumped;
    //[HideInInspector]

    private void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerRigidbody2D.linearVelocityX = moveDirection.x * moveSpeed;

        if(hasJumped )
        {
            playerRigidbody2D.linearVelocityY = jumpForce;
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
