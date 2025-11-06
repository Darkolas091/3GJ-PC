using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicsManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextCinematicScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousCinematicScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void LoadLevel1Scene()
    {
        SceneManager.LoadScene("Level1");
    }
}
