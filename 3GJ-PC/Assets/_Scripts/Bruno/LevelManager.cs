using System;
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
    [SerializeField] private GameObject deathScreenPanel;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private bool playerInWinArea = false;
    [SerializeField] private bool cloneInWinArea = false;
    [SerializeField] private int levelIntroPanelNumberAdjustment = 4;

    public static Action OnPlayerDeath;

    void Start()
    {
        StartCoroutine(ShowLevelIntro());
        pauseMenuPanel.SetActive(false);
        deathScreenPanel.SetActive(false);
    }

    IEnumerator ShowLevelIntro()
    {
        levelIntroPanel.SetActive(true);
        introPanelLevelText.text = $"Level {SceneManager.GetActiveScene().buildIndex - levelIntroPanelNumberAdjustment}";   // this needs to be adjusted when all scenes in scene manager are finally set
        yield return new WaitForSeconds(3f);
        levelIntroPanel.SetActive(false);
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuPanel.SetActive(true);
            Debug.Log("game paused");
        }

    }

    public void PlayerDeath()
    {
        deathScreenPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuPanel.SetActive(false);
            Debug.Log("game unpaused");
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
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
            Time.timeScale = 0;
        }
    }

    private void OnEnable()
    {
        OnPlayerDeath += PlayerDeath;
    }

    private void OnDisable()
    {
        OnPlayerDeath -= PlayerDeath;

    }
}