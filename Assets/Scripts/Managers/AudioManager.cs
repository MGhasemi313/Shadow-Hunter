using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;


    [SerializeField]
    private AudioSource musicSource;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SetVolume(float volume)
    {
        Debug.Log("Volume : " + volume);
        musicSource.volume = volume;

        PlayerPrefs.SetFloat(
            "Volume",
            volume);
    }


    void Start()
    {
        float volume =
        PlayerPrefs.GetFloat(
        "Volume",
        1);

        musicSource.volume = volume;
    }
}