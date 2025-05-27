using UnityEngine;

public class PlatformBreak : MonoBehaviour
{
    
    [SerializeField] private float destructionDelay = 2f;     // Delay before destruction in seconds
    [SerializeField] private float respawnDelay = 5f;     // Delay before respawn in seconds
    [SerializeField] private Animator animator;         // Animator component for the platform

    private float destructionTimer = -1f;
    private float respawnTimer = -1f;
    private Collider2D platformCollider;
    private Renderer platformRenderer;

    private void Awake()
    {
        platformCollider = GetComponent<Collider2D>();
        platformRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
             player player = collision.gameObject.GetComponent<player>();
        if (player)
        {
                if (collision.contacts[0].normal.y < -0.5f)
            {
                animator.SetTrigger("BreakThis");
                destructionTimer = destructionDelay;
                respawnTimer = respawnDelay;
            }
        }
    }

    void Update()
    {
        if (destructionTimer > 0f)
        {
            destructionTimer -= Time.deltaTime;
            if (destructionTimer <= 0f)
            {
                DestroyPlatform();
            }
        }

        if (respawnTimer > 0f)
        {
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0f)
            {
                RestorePlatform();
            }
        }
    }

    private void DestroyPlatform()
    {
          foreach (var col in GetComponentsInChildren<Collider2D>())
        col.enabled = false;
        foreach (var rend in GetComponentsInChildren<Renderer>())
        rend.enabled = false;
    }

    private void RestorePlatform()
    {
        // Restore the idle animation
        animator.ResetTrigger("BreakThis");
        animator.SetTrigger("Respawn");
        foreach (var col in GetComponentsInChildren<Collider2D>())
            col.enabled = true;
        foreach (var rend in GetComponentsInChildren<Renderer>())
        rend.enabled = true;
    }
}