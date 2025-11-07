using UnityEngine;
using TMPro;

public class HoverTextColorChangeExitButton : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Assign your TextMeshPro component in the Inspector
    public Color hoverColor = Color.red; // Color when hovered
    public Color defaultColor = Color.white; // Default color

    private void Start()
    {
        // Ensure the text starts with the default color
        if (textMeshPro == null)
            textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.color = defaultColor;
    }

    private void OnMouseEnter()
    {
        // Change to hover color when the mouse enters
        textMeshPro.color = hoverColor;
    }

    private void OnMouseExit()
    {
        // Revert to default color when the mouse exits
        textMeshPro.color = defaultColor;
    }
}
