using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject objectToTeleport; // Object to be teleported
    [SerializeField] private Transform teleportTarget;    // Target object for teleportation
    [SerializeField] private GameObject teleportTargetAnimator;
    [SerializeField] private AudioClip teleportSFX;
    [SerializeField, Range(0f, 1f)] private float volume = 1f;
    [SerializeField] private string animatorTrigger = "EnterTeleport";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if object receiving this script is colliding with the object to be teleported
        if (collision.gameObject == objectToTeleport)
        {
            // Teleport the object to be teleported to the target position
            if (teleportTarget != null)
            {
                objectToTeleport.transform.position = teleportTarget.position;

                Animator thisAnimator = GetComponent<Animator>();
                if (thisAnimator != null && !string.IsNullOrEmpty(animatorTrigger))
                {
                    thisAnimator.SetTrigger(animatorTrigger);
                }

                Animator teleportAnimator = teleportTargetAnimator.GetComponent<Animator>();
                if (teleportAnimator != null && !string.IsNullOrEmpty(animatorTrigger))
                {
                    teleportAnimator.SetTrigger(animatorTrigger);
                }
            }
            if (teleportSFX != null)
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = teleportSFX;
                audioSource.volume = volume;
                audioSource.playOnAwake = false;
                audioSource.Play();
                Destroy(audioSource, teleportSFX.length);
            }
        }

    }
}
