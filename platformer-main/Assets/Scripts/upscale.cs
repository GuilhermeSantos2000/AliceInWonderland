using UnityEngine;

public class upscale : MonoBehaviour
{
   [SerializeField] private ParticleSystem burstParticleSystem;
   [SerializeField] private SpriteRenderer gem;
   [SerializeField] private bool burstAvailable = true;
   [SerializeField] private AudioClip eatMeSFX;
    [SerializeField, Range(0f, 1f)] private float volume = 1f;
    
    [SerializeField] private string sizeBool = "AliceIsSmall";

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

            float emissionDuration = burstParticleSystem.main.duration;
            ParticleSystem.EmissionModule emmisor = burstParticleSystem.emission;

            other.transform.localScale = other.transform.localScale * scaleMultiplier; // scale the character down
            player.velocity = new Vector2(player.velocity.x, player.velocity.y +100f); 
            Animator anim = other.GetComponent<Animator>();
            if (anim != null && !string.IsNullOrEmpty(sizeBool))
            {
                anim.SetBool(sizeBool, false);
            }

            emmisor.enabled = true;
            burstParticleSystem.Play();
            burstAvailable = false;
            Destroy(gem, emissionDuration);

        }
    }
   

}
