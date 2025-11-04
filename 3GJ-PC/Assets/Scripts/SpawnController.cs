using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private Transform playerSpawnTransform;
    [SerializeField] private Transform cloneSpawnTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(playerPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation);
        Instantiate(clonePrefab, cloneSpawnTransform.position, cloneSpawnTransform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
