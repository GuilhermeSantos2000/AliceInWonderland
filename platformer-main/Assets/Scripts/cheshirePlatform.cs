using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class cheshirePlatform : MonoBehaviour
{

    [SerializeField] private TilemapRenderer CheshireRenderer;
    [SerializeField] private Tilemap CheshireTilemap;
    [SerializeField] private TilemapCollider2D CheshireCollider;

    [SerializeField] private PlatformEffector2D CheshireEffector;

    [SerializeField] private int duration;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CheshireRenderer.enabled = true;
            CheshireTilemap.enabled = true;
            CheshireCollider.enabled = true;
            CheshireEffector.enabled = true;

            StartCoroutine(DisableChesire(duration));
        }
    }

    private IEnumerator DisableChesire(float duration)
    {
        yield return new WaitForSeconds(duration);

        CheshireRenderer.enabled = false;
        CheshireTilemap.enabled = false;
        CheshireCollider.enabled = false;
        CheshireEffector.enabled = false;
    }
}
