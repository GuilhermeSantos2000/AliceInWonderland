using OkapiKit.Editor;
using UnityEngine;

public class cheshireManager : MonoBehaviour
{

    [SerializeField] private GameObject[] cheshirePlatforms;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float minDistance = 20f;

    [SerializeField] private float platformCooldown = 2f;
    [SerializeField] private float platformTimer = 5f;

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

    private float platformDuration = 5f;

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
                        platformTimers[i] = platformDuration;
                        
                    }
                }
            }

            }
    }
}
