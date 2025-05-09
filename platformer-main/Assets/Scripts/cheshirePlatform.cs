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
    [SerializeField] private float cooldown;
    bool isOnCooldown = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isOnCooldown == false)
        {
            CheshireRenderer.enabled = true;
            CheshireTilemap.enabled = true;
            CheshireCollider.enabled = true;
            CheshireEffector.enabled = true;

            StartCoroutine(DisableChesire(duration));
            isOnCooldown = true;
        }
    }

    private IEnumerator DisableChesire(float duration)
    {
        yield return new WaitForSeconds(duration);

        CheshireRenderer.enabled = false;
        CheshireTilemap.enabled = false;
        CheshireCollider.enabled = false;
        CheshireEffector.enabled = false;
        StartCoroutine(Cooldown(cooldown));
    }

    private IEnumerator Cooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
    }
}
