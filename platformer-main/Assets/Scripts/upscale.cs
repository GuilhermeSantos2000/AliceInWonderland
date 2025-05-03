using UnityEngine;

public class upscale : MonoBehaviour
{
   [SerializeField] private ParticleSystem burstParticleSystem;
   [SerializeField] private SpriteRenderer gem;
   [SerializeField] private bool burstAvailable = true;

   private float scaleMultiplier = 2f; // multiplier for the scale of the character on collision with the gem
   private Vector3 originalScale; // original size of the character

    private void Start()
    {
    originalScale = transform.localScale; // Save the original scale of the player
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && burstAvailable)
        {
            float emissionDuration = burstParticleSystem.main.duration;
            ParticleSystem.EmissionModule emmisor = burstParticleSystem.emission;

            other.transform.localScale = other.transform.localScale * scaleMultiplier; // scale the character down
            

            emmisor.enabled = true;
            burstParticleSystem.Play();
            burstAvailable = false;
            Destroy(gem, emissionDuration); 
        }
    }
   

}
