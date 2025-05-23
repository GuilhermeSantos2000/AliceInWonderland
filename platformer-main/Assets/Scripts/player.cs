using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class player : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    private Rigidbody2D body;
    private SpriteRenderer sprite;

    private Quaternion initialRotation;

    private bool isGrounded = true;

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
        float movedir = Input.GetAxis("Horizontal");

        Vector2 currentVelocity = body.linearVelocity;

        currentVelocity.x = movedir * velocity.x;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jumping!");
            currentVelocity.y = velocity.y;
        }

        if (movedir < 0)
        {
            transform.rotation = initialRotation * Quaternion.Euler(0, 180f, 0);
        }
        else if (movedir > 0)
        {
            transform.rotation = initialRotation;
        }

        body.linearVelocity = currentVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("Grounded!");
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        Debug.Log("Not Grounded!");
        isGrounded = false;
    }
}
