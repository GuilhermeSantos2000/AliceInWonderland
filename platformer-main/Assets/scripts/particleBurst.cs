using UnityEngine;

public class particleBurst : MonoBehaviour
{
   [SerializeField] private ParticleSystem burstParticleSystem;

   [SerializeField] private SpriteRenderer gem;
   [SerializeField] private bool burstAvailable = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && burstAvailable)
        {
            float emissionDuration = burstParticleSystem.main.duration;
            ParticleSystem.EmissionModule emmisor = burstParticleSystem.emission;

            emmisor.enabled = true;
            burstParticleSystem.Play();
            burstAvailable = false;
            Destroy(gem, emissionDuration); 
        }
    }
   

}
