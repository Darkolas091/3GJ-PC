using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialCollectable : MonoBehaviour
{
    //[SerializeField] private Image specialCollectableImage;
    [SerializeField] private TMP_Text specialCollectableText;
    private bool isCollected;

    private void Awake()
    {
        //specialCollectableImage.gameObject.SetActive(true);
        specialCollectableText.gameObject.SetActive(true);
        specialCollectableText.text = "0/1";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInputHandler>())
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            isCollected = true;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        if (isCollected)
        {
            specialCollectableText.gameObject.SetActive(true);
            specialCollectableText.text = "1/1";
            //specialCollectableImage.gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }

}
