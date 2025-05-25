using UnityEngine;

public class upscale : MonoBehaviour
{
   [SerializeField] private ParticleSystem burstParticleSystem;
   [SerializeField] private SpriteRenderer gem;
   [SerializeField] private bool burstAvailable = true;
   [SerializeField] private AudioClip eatMeSFX;
    [SerializeField, Range(0f, 1f)] private float volume = 1f;

   private float scaleMultiplier = 2f; // multiplier for the scale of the character on collision with the gem
   private Vector3 originalScale; // original size of the character

    private void Start()
    {
    originalScale = transform.localScale; // Save the original scale of the player
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player player = other.GetComponent<player>();
        if (player && burstAvailable)
        {
            if (eatMeSFX != null)
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = eatMeSFX;
                audioSource.volume = volume;
                audioSource.playOnAwake = false;
                audioSource.Play();
                Destroy(audioSource, eatMeSFX.length);
            }
            // turn on emmisor and play the particle burst only once
            float emissionDuration = burstParticleSystem.main.duration;
            ParticleSystem.EmissionModule emmisor = burstParticleSystem.emission;
            emmisor.enabled = true;
            burstParticleSystem.Play();
            burstAvailable = false;
            Destroy(gem, emissionDuration);

            other.transform.localScale = other.transform.localScale * scaleMultiplier; // scale the character up



        }
    }
   

}
