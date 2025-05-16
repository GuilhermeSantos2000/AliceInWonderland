using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class Spikes : MonoBehaviour
{
    [SerializeField] private string triggeringTag = "Player"; // Tag of the object that triggers the scene restart

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag(triggeringTag))
        {
            // Restart the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
