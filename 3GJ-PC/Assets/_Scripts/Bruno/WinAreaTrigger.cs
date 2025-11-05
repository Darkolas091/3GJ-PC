using UnityEngine;

public class WinAreaTrigger : MonoBehaviour
{
    [SerializeField] private bool isPlayerWinArea;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject flag;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isPlayerWinArea && other.TryGetComponent<CharacterController>(out CharacterController player))
        {
            levelManager.PlayerEnteredWinArea();
            flag.SetActive(false);
            Debug.Log($"PlayerEnteredWinArea");
        }
        else if (!isPlayerWinArea && other.TryGetComponent<CloneController>(out CloneController clone))
        {
            levelManager.CloneEnteredWinArea();
            flag.SetActive(false);
            Debug.Log($"CloneEnteredWinArea");
        }
    }
}