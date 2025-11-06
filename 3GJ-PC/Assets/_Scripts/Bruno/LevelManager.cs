using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TMP_Text introPanelLevelText;
    [SerializeField] private GameObject levelIntroPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private bool playerInWinArea = false;
    [SerializeField] private bool cloneInWinArea = false;


    void Start()
    {
        StartCoroutine(ShowLevelIntro());
        pauseMenuPanel.SetActive(false);
    }

    IEnumerator ShowLevelIntro()
    {
        levelIntroPanel.SetActive(true);
        introPanelLevelText.text = $"Level {SceneManager.GetActiveScene().buildIndex.ToString()}";   // this needs to be adjusted when all scenes in scene manager are finally set
        yield return new WaitForSeconds(3f);
        levelIntroPanel.SetActive(false);
    }

    public void PauseGame()
    {
        if (Input.GetKey(KeyCode.A))
        {
            pauseMenuPanel.SetActive(true);
        }

    }

    public void ResumeGame()
    {
        if (Input.GetKey(KeyCode.A))
        {
            pauseMenuPanel.SetActive(false);
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerEnteredWinArea()
    {
        playerInWinArea = true;
        CheckWinCondition();
    }

    public void CloneEnteredWinArea()
    {
        cloneInWinArea = true;
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (playerInWinArea && cloneInWinArea)
        {
            winPanel.SetActive(true);
        }
    }

}