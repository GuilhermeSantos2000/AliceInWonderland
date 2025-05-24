using UnityEngine;

public class cheshireTimer : MonoBehaviour
{

    [SerializeField] private float platformCooldown = 2f;
    private float timer = 5f;



    void Update()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime;


            if (timer <= 0)
            {
                gameObject.SetActive(false);


            }
        }

    }


    public void ActivateTimer(float duration)
    {

        timer = duration;
        gameObject.SetActive(true);

    }
}
