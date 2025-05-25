using UnityEngine;

public class PlatformBreak : MonoBehaviour
{
    
    [SerializeField] private float destructionDelay = 2f;     // Delay before destruction in seconds
    [SerializeField] private float respawnDelay = 5f;     // Delay before respawn in seconds
    [SerializeField] private Animator animator;         // Animator component for the platform

    private void OnCollisionEnter2D(Collision2D collision)
    {
            player player = collision.gameObject.GetComponent<player>();
        if (player)
        {
            // Check if the collision is coming from above
            if (collision.contacts[0].normal.y < -0.5f) // Normal.y < -0.5f indicates collision from above
            {
                // Trigger the break animation
                animator.SetTrigger("BreakThis");
                // Start the destruction process with a delay
                Invoke(nameof(DestroyPlatform), destructionDelay);
                // Start the respawn process with a delay
                Invoke(nameof(RestorePlatform), respawnDelay);
            }
        }
    }

    private void DestroyPlatform()
    {
        gameObject.SetActive(false); // Deactivate the platform
    }

    private void RestorePlatform()
    {
        // Restore the idle animation
        animator.SetTrigger("Respawn");

        gameObject.SetActive(true); // Deactivate the platform
    }
}
