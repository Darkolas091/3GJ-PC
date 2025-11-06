using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using System.Collections;

public class TypewriterWritingEffect : MonoBehaviour
{
    [SerializeField] private float charactersPerSecond = 5;
    [SerializeField] private TMP_Text dialogueText;

    private IEnumerator TypeText(string line)
    {
        string textBuffer = null;
        foreach (char c in line)
        {
            textBuffer += c;
            dialogueText.text = textBuffer;
            yield return new WaitForSeconds(1 / charactersPerSecond);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine((TypeText(dialogueText.text)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
