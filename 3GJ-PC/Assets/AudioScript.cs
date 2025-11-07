using UnityEngine;


public class AudioScript : MonoBehaviour
{
    public static AudioScript Instance;
    [SerializeField] AudioSource music;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else 
        {
            Destroy(gameObject);
            return;

        }
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        music.Play();
    }
}
