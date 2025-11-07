using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Text volumeText;
    [SerializeField] private GameObject howToPlayPanel;

    private void Start()
    {
        volumeSlider.value = 1.0f;
        volumeText.text = $"100%";
    }

    public void OnVolumeChanged()
    {
        volumeText.text = $"{Mathf.RoundToInt(volumeSlider.value * 100.0f)}%";
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Cinematic1"); // Change "Level1" to your level scene name
    }

    public void OpenOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }

    public void OpenHowToPlayPanel()
    {
        howToPlayPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}