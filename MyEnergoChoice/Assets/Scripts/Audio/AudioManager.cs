using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource audioSource;
    [SerializeField] AudioClip backgroundMusic1;
    [SerializeField] AudioClip backgroundMusic2;
    [SerializeField] AudioClip finalMusic;
    [SerializeField] private string sceneToDestroyOn1;
    [SerializeField] private string sceneToDestroyOn2;
    [SerializeField] private string sceneToDestroyOn3;
    private bool inMenu;
    private bool inMap;
    private bool inFinal;

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAudio();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeAudio()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneToDestroyOn1&&!inMenu)
        {
            audioSource.loop = true;
            inMap = false;
            inFinal = false;
            audioSource.clip = backgroundMusic1;
            audioSource.Play();
            inMenu = true;
            
        }
        if (scene.name == sceneToDestroyOn2 && !inMap)
        {
            audioSource.loop = true;
            inMenu = false;
            inFinal = false;
            audioSource.clip = backgroundMusic2;
            audioSource.Play();
            inMap = true;

        }
        if (scene.name == sceneToDestroyOn3 && !inFinal)
        {
            audioSource.loop = false;
            audioSource.clip=finalMusic;
            audioSource.Play();
            inMenu = false;
            inMap = false;
            inFinal = true;

        }
    }

    private void Update()
    {
        audioSource.volume = GameData.MusicVolume;
    }
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}