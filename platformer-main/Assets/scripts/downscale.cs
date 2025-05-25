using UnityEngine;

public class particleBurst_dowscale : MonoBehaviour
{
   [SerializeField] private ParticleSystem burstParticleSystem;
   [SerializeField] private SpriteRenderer gem;
   [SerializeField] private bool burstAvailable = true;
   [SerializeField] private AudioClip drinkMeSFX;
    [SerializeField, Range(0f, 1f)] private float volume = 1f;
    [SerializeField] private string sizeBool = "AliceIsSmall";

   private float scaleMultiplier = 0.5f; // multiplier for the scale of the character on collision with the gem
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

            if (drinkMeSFX != null)
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = drinkMeSFX;
                audioSource.volume = volume;
                audioSource.playOnAwake = false;
                audioSource.Play();
                Destroy(audioSource, drinkMeSFX.length);
            }

            float emissionDuration = burstParticleSystem.main.duration;
            ParticleSystem.EmissionModule emmisor = burstParticleSystem.emission;

            other.transform.localScale = other.transform.localScale * scaleMultiplier; // scale the character down

            Animator anim = other.GetComponent<Animator>();
            if (anim != null && !string.IsNullOrEmpty(sizeBool))
            {
                anim.SetBool(sizeBool, true);
            }

            emmisor.enabled = true;
            burstParticleSystem.Play();
            burstAvailable = false;
            Destroy(gem, emissionDuration);
        }
    }
   

}
