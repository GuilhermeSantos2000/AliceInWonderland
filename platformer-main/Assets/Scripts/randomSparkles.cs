using UnityEngine;

public class randomSparkles : MonoBehaviour
{
    [SerializeField]private Sprite[] sparkles;
    private SpriteRenderer sparkleRenderer;

    void Start()
    {
        sparkleRenderer = GetComponent<SpriteRenderer>();
        RandomSparkles();
    } 

    private void RandomSparkles()
    {
        if (sparkles.Length > 0)
        {
            int randomSparkles = Random.Range(0, sparkles.Length);

            sparkleRenderer.sprite = sparkles[randomSparkles];
        }
    }
}
