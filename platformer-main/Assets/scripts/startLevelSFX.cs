using UnityEngine;

public class startLevelSFX : MonoBehaviour
{
    [SerializeField] private AudioClip startSFX;
    [SerializeField, Range(0f, 1f)] private float volume = 1f;

    void Start()
    {
        if (startSFX != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = startSFX;
            audioSource.volume = volume;
            audioSource.playOnAwake = false;
            audioSource.Play();
            Destroy(audioSource, startSFX.length);
        }
    }
}
