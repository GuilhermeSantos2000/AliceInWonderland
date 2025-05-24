using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    [SerializeField] private string triggeringTag = "Player";
    [SerializeField] private AudioClip sfx;
    [SerializeField, Range(0f, 1f)] private float sfxVolume = 1f;

    private bool triggered = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (triggered) return;

        if (collision.gameObject.CompareTag(triggeringTag))
        {
            triggered = true;
            PlaySFXAndRestart();
        }
    }

    private void PlaySFXAndRestart()
    {
        if (sfx != null)
        {
            GameObject sfxPlayer = new GameObject("SpikesSFX");
            DontDestroyOnLoad(sfxPlayer);
            AudioSource audioSource = sfxPlayer.AddComponent<AudioSource>();
            audioSource.clip = sfx;
            audioSource.volume = sfxVolume;
            audioSource.Play();
            Destroy(sfxPlayer, sfx.length);
            Invoke(nameof(RestartScene), sfx.length);
        }
        else
        {
            RestartScene();
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
