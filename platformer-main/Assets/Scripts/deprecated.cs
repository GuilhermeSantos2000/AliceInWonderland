using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem ExplosionParticle;
    [SerializeField] private ParticleSystem BubblesParticle;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ExplosionParticle.Play();
        }        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BubblesParticle.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            BubblesParticle.Stop();
        }
    }
}
