using OkapiKit.Editor;
using UnityEngine;

public class cheshireManager : MonoBehaviour
{

    [SerializeField] private GameObject[] cheshirePlatforms;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float minDistance = 20f;

    [SerializeField] private float platformCooldown = 2f;
    [SerializeField] private float platformTimer = 5f;

    [SerializeField] private AudioClip activateSFX;
    [SerializeField, Range(0f, 1f)] private float sfxVolume = 1f;

    private float[] platformCooldowns;
    private float[] platformTimers;

    void Start()
    {
        if (cheshirePlatforms != null && cheshirePlatforms.Length > 0)
        {
            platformCooldowns = new float[cheshirePlatforms.Length];
            platformTimers = new float[cheshirePlatforms.Length];
        }
    }

    void Update()
    {
        for (int i = 0; i < cheshirePlatforms.Length; i++)
        {
            if (platformTimers[i] > 0)
            {
                platformTimers[i] -= Time.deltaTime;

                if (platformTimers[i] <= 0)
                {
                    cheshirePlatforms[i].SetActive(false);
                    platformCooldowns[i] = platformCooldown;
                }
            }

            if (platformCooldowns[i] > 0)
            {
                platformCooldowns[i] -= Time.deltaTime;
            }
            else
            {
                platformCooldowns[i] = 0f; 
            } 
        }

        if (Input.GetKeyDown(KeyCode.F) && playerTransform != null)
        {
            for (int i = 0; i < cheshirePlatforms.Length; i++)
            {
                GameObject platform = cheshirePlatforms[i];
                if (platform != null && platform.activeSelf == false && platformCooldowns[i] <= 0f)
                {
                    if (Vector2.Distance(playerTransform.position, platform.transform.position) <= minDistance)
                    {
                        platform.SetActive(true);
                        platformTimers[i] = platformTimer;
                        
                        if (activateSFX != null)
                        {
                            GameObject sfxPlayer = new GameObject("PlatformActivateSFX");
                            AudioSource audioSource = sfxPlayer.AddComponent<AudioSource>();
                            audioSource.clip = activateSFX;
                            audioSource.volume = sfxVolume;
                            audioSource.Play();
                            Destroy(sfxPlayer, activateSFX.length);
                        }
                    }
                }
            }

            }
    }
}
