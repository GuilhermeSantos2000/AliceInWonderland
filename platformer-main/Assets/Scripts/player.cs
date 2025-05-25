using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class player : MonoBehaviour
{
    [SerializeField] public Vector2 velocity;
    [SerializeField] private Animator animator;

    [SerializeField] private string movingBool = "AliceIsRunning";
    [SerializeField] private string jumpingBool = "AliceIsJumping";

    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Quaternion initialRotation;

    private bool isGrounded = true;

    private float gracePeriod = 0.2f;
    private float? lastGroundedTime;
    private float? lastJumpTime;
    bool alreadyJumped = false;
    



   
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();

        initialRotation = transform.rotation;

    }

    void Update()
    {
        float movedir = Input.GetAxis("Horizontal");

        Vector2 currentVelocity = body.linearVelocity;

        currentVelocity.x = movedir * velocity.x;

        if (animator != null)
            animator.SetBool(movingBool, Mathf.Abs(movedir) > 0.01f && isGrounded);

        if (isGrounded)
        {
            lastGroundedTime = Time.time; // checks when the player was last grounded

        }

        bool doJump = Time.time - lastGroundedTime <= gracePeriod && Time.time - lastJumpTime <= gracePeriod;

        if (animator != null)
            animator.SetBool(jumpingBool, !isGrounded || doJump);

        if (Input.GetButtonDown("Jump"))
        {
            lastJumpTime = Time.time; // checks when the player last jumped
        }

        if (!alreadyJumped && Time.time - lastGroundedTime <= gracePeriod && Time.time - lastJumpTime <= gracePeriod)
        {
            Debug.Log("Jumping!");
            currentVelocity.y = velocity.y;
            lastGroundedTime = null;
            lastJumpTime = null;
            alreadyJumped = true;
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
        foreach (ContactPoint2D surface in collider.contacts)
        {
            if (surface.normal.y > 0.5f)
            {
                Debug.Log("Grounded!");
                isGrounded = true;
                alreadyJumped = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        Debug.Log("Not Grounded!");
        isGrounded = false;
    }
}
