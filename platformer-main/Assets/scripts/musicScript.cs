using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class musicScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] playlist;
    [SerializeField, Range(0f, 1f)] private float volume = 0.5f;

    private AudioSource audioSource;
    private int currentTrack = 0;
    private static musicScript instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.volume = volume;
        audioSource.playOnAwake = false;
    }

    void Start()
    {
        PlayCurrentTrack();
    }

    void Update()
    {
        if (!audioSource.isPlaying && playlist.Length > 0)
        {
            currentTrack = (currentTrack + 1) % playlist.Length;
            PlayCurrentTrack();
        }
    }

    private void PlayCurrentTrack()
    {
        if (playlist.Length == 0) return;
        audioSource.clip = playlist[currentTrack];
        audioSource.Play();
    }
}