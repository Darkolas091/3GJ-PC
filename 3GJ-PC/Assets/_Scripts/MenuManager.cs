using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public Slider volumeSlider;
    public TMP_Text volumeText;
    public GameObject howToPlayPanel;

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
        SceneManager.LoadScene("Level1"); // Change "Level1" to your level scene name
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