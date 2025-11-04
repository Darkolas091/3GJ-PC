using UnityEngine;

public class WinAreaTrigger : MonoBehaviour
{
    public bool isPlayerWinArea;
    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isPlayerWinArea && other.CompareTag("Player"))
        {
            levelManager.PlayerEnteredWinArea();
        }
        else if (!isPlayerWinArea && other.CompareTag("Clone"))
        {
            levelManager.CloneEnteredWinArea();
        }
    }
}