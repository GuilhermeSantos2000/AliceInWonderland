using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class cheshirePlatform : MonoBehaviour
{

    [SerializeField] private TilemapRenderer CheshireRenderer;
    [SerializeField] private Tilemap CheshireTilemap;
    [SerializeField] private TilemapCollider2D CheshireCollider;
    [SerializeField] private PlatformEffector2D CheshireEffector;
    [SerializeField] private float duration;
    [SerializeField] private float cooldown;
    bool isOnCooldown = false;

    [SerializeField] private GameObject durationUI;

    [SerializeField] private GameObject cooldownUI;
    private Slider durationSlider;
    private Slider cooldownSlider;

    void Start()
    {
        durationSlider = durationUI.GetComponentInChildren<Slider>();
        cooldownSlider = cooldownUI.GetComponentInChildren<Slider>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isOnCooldown == false)
        {
            CheshireRenderer.enabled = true;
            CheshireTilemap.enabled = true;
            CheshireCollider.enabled = true;
            CheshireEffector.enabled = true;
            isOnCooldown = true;
            
            //UI indicator
            durationUI.SetActive(true);
            StartCoroutine(UpdateSlider(duration));
        }
    }



    private IEnumerator Cooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
        cooldownUI.SetActive(false);
    }

    private IEnumerator UpdateSlider(float duration)
    {
        float timeLeft = duration;
        float cooldownLeft = cooldown;
        durationSlider.maxValue = duration;
        durationSlider.value = duration;
        cooldownSlider.maxValue = cooldown;
        cooldownSlider.value = cooldown;

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            durationSlider.value = Mathf.Max(0, timeLeft);
            yield return null;
        }

        CheshireRenderer.enabled = false;
        CheshireTilemap.enabled = false;
        CheshireCollider.enabled = false;
        CheshireEffector.enabled = false;
        durationUI.SetActive(false);
    
        StartCoroutine(Cooldown(cooldown));
        cooldownUI.SetActive(true);

        while (cooldownLeft > 0)
        {
            cooldownLeft -= Time.deltaTime;
            cooldownSlider.value = Mathf.Max(0, cooldownLeft);
            yield return null;
        }


    }
}
