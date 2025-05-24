using System.Collections;
using System.Threading;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class cheshirePlatform : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; 
   
    [SerializeField] private float duration;
    [SerializeField] private float cooldown;
    bool isOnCooldown = false;

    private float timer = 0f; 
    private float cooldownTimer = 0f;

    private int distance = 20; // Distance at which the player can activate the Cheshire platform

    void Start()
    {
        

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isOnCooldown == false)
        {
            // Check if the player is within the distance to activate the Cheshire platform
            if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) <= distance)
            {
                // Activate the Cheshire platform
                gameObject.SetActive(true);
                isOnCooldown = true;
                
                Debug.Log("Cheshire platform activated!");
            }
            else
            {
                Debug.Log("Player is too far away to activate the Cheshire platform.");
            }

            
        }

    }

    private IEnumerator Cooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
        Debug.Log("Cheshire platform is ready to be activated again!");
    }

    
}


    
