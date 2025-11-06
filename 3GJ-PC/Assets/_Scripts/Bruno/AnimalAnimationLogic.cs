using UnityEngine;

public class AnimalAnimationLogic : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInputHandler>())
        {
        animator.SetBool("triggerActivated", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInputHandler>())
        {
            animator.SetBool("triggerActivated", false);
        }

    }
}
