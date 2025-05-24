using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class nextLevel : MonoBehaviour
{
    [SerializeField] private string triggeringTag = "Player"; // Tag of the object that triggers the scene change
    [SerializeField] private string nextSceneName; // Name of the scene to load

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag(triggeringTag))
        {
            // Load the specified scene
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
