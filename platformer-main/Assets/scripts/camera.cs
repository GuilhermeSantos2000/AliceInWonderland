
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private Transform targetEntity;
    [SerializeField] private Vector3 offset; 
    [SerializeField] private float maxspeed;
    [SerializeField] private float pandown;

    [SerializeField] private Vector2 minBounds; 
    [SerializeField] private Vector2 maxBounds; 
    [SerializeField] private float smoothTime = 0.07f; 
    private Vector3 velocity = Vector3.zero;

   
    void Start()
    {
        
    }

    
    void  FixedUpdate()
    {

        Vector3 currentTarget = GetTargetPosition(); 
        currentTarget.z = transform.position.z; // this keeps the camera from moving on the z axis
        currentTarget = currentTarget + offset; // offset in case we wanna use it later

        if (Vector3.Distance(transform.position, currentTarget) > 400f)
        {
            transform.position = currentTarget; // this will snap the camera back to the target if it is too far away 
        }
        else
        {
             transform.position = Vector3.SmoothDamp(transform.position, currentTarget, ref velocity, smoothTime);
    }
    }

    void LateUpdate()
    {
        Vector3 clampedPosition = transform.position;

        // Limits the camera position within the defined bounds
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBounds.x, maxBounds.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minBounds.y, maxBounds.y);

        // applies the clamped position to the camera
        transform.position = clampedPosition;
    }

    Vector3 GetTargetPosition()
    {
        return targetEntity.position; // this will get the target position
    }

    
   
}

