using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
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
    [SerializeField] private WinPanel winPanelScript;
    [SerializeField] private Timer timerScript;

    [SerializeField] int[] scene;

    public static Action OnPlayerDeath;

    void Start()
    {
        StartCoroutine(ShowLevelIntro());
        pauseMenuPanel.SetActive(false);
        deathScreenPanel.SetActive(false);

        
        
    }

    private void Update()
    {
        PauseGame();
        SkipLevel();
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
            Time.timeScale = 0;
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
       
            pauseMenuPanel.SetActive(false);
            Time.timeScale = 1;
            Debug.Log("game unpaused");
        
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
            winPanelScript.StarsCollected(timerScript.GetTime());
        }

    }

    private void SkipLevel()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            SceneManager.LoadSceneAsync(scene[0]);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SceneManager.LoadSceneAsync(scene[1]);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            SceneManager.LoadSceneAsync(scene[2]);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            SceneManager.LoadSceneAsync(scene[3]);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            SceneManager.LoadSceneAsync(scene[4]);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            SceneManager.LoadSceneAsync(scene[5]);
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            SceneManager.LoadSceneAsync(scene[6]);
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            SceneManager.LoadSceneAsync(scene[7]);
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            SceneManager.LoadSceneAsync(scene[8]);
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            SceneManager.LoadSceneAsync(scene[9]);
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