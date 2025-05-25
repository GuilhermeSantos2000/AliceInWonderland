using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class nextLevel : MonoBehaviour
{
    
    [SerializeField] private string nextSceneName; // Name of the scene to load

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player player = collision.gameObject.GetComponent<player>();
        if (player)
        {
            // Load the specified scene
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
