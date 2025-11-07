using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeHazard : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInputHandler>())
        {
            Destroy(other.gameObject);
            LevelManager.OnPlayerDeath?.Invoke();
        }
    }

}
