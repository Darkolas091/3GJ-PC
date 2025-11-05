using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialCollectable : MonoBehaviour
{
    [SerializeField] private Image specialCollectable;
    [SerializeField] private TMP_Text specialCollectableText;
    private bool isCollected;

    private void Awake()
    {
        specialCollectable.gameObject.SetActive(false);
        specialCollectableText.gameObject.SetActive(false);
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
            specialCollectableText.text = "1";
            specialCollectable.gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }

}
