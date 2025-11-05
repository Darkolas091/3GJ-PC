using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeHazard : MonoBehaviour
{

    [SerializeField] private LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInputHandler>())
        {
            Destroy(other.gameObject);
            levelManager.RestartLevel();
        }
    }

}
