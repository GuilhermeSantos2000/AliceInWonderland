using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Spikes : MonoBehaviour
{

    [SerializeField] private AudioClip sfx;
    [SerializeField, Range(0f, 1f)] private float sfxVolume = 1f;

    private bool triggered = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (triggered) return;

        player player = collision.gameObject.GetComponent<player>();

        if (player)
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
            StartCoroutine(RestartAfterSFX(sfx.length));
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

    private IEnumerator RestartAfterSFX(float soundEffect)
    {
        yield return new WaitForSeconds(soundEffect);
        RestartScene();
    }
}
