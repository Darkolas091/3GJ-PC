using UnityEngine;
using UnityEngine.UI;

public class KeyItem : MonoBehaviour
{
    [SerializeField] private LockedDoor linkedDoor;
    //[SerializeField] private Image keyImage;

    private void Awake()
    {
        //keyImage.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInputHandler>()) 
        {
            if (linkedDoor != null)
                linkedDoor.UnlockDoor(); 
            
            Destroy(gameObject);
            //keyImage.gameObject.SetActive(true);
        }
    }
}
