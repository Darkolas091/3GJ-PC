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

    private void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);

    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
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