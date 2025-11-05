using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [SerializeField] private LockedDoor linkedDoor; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInputHandler>()) 
        {
            if (linkedDoor != null)
                linkedDoor.UnlockDoor(); 
            
            gameObject.SetActive(false); 
        }
    }
}
