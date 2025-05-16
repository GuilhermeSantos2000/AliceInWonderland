using UnityEngine;
using UnityEngine.PlayerLoop;

public class player : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer sprite;

    private Quaternion initialRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();

        initialRotation = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
