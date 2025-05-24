using UnityEngine;

public class cheshireManager : MonoBehaviour
{

    [SerializeField] private GameObject[] cheshirePlatforms;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float minDistance = 20f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerTransform != null)
        {
            foreach (GameObject platform in cheshirePlatforms)
            {
                if (platform != null)
                {
                    float dist = Vector3.Distance(playerTransform.position, platform.transform.position);
                    if (dist <= minDistance)
                    {
                        platform.SetActive(true);
                    }
                }
            }
        }
    }
}
