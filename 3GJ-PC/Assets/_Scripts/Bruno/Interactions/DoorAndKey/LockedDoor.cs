using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] public bool isUnlocked = false;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        UpdateColliderState();
    }

    public void UpdateColliderState()
    {
        isUnlocked = false;
        boxCollider.isTrigger = isUnlocked;
    }

    public void UnlockDoor()
    {
        isUnlocked = true;
        boxCollider.isTrigger = isUnlocked;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isUnlocked && other.GetComponent<PlayerInputHandler>())
        {
            Destroy(gameObject);
        }
    }
}
