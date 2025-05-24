using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private Transform targetEntity;
    [SerializeField] private Vector3 offset; 
     private Vector2 minBounds; 
     private Vector2 maxBounds; 
    [SerializeField] private float smoothTime = 0.09f; 
    private Vector2 velocity = Vector2.zero;


    void Start()
    {
        GameObject limitBox = GameObject.Find("CameraBoundingBox");
        {
            BoxCollider2D boundsCollider = limitBox.GetComponent<BoxCollider2D>();
            minBounds = boundsCollider.bounds.min;
            maxBounds = boundsCollider.bounds.max;
        }
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
            transform.position = Vector2.SmoothDamp(transform.position, currentTarget, ref velocity, smoothTime);
    }
    }

    void LateUpdate()
    {
        Camera cameraComp = GetComponent<Camera>();
        float halfVertCamera = cameraComp.orthographicSize;
        float halfHorizCamera = halfVertCamera * cameraComp.aspect;
        Vector3 clampedPosition = transform.position;
        // Limits the camera position within the defined bounds
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBounds.x + halfHorizCamera, maxBounds.x - halfHorizCamera);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minBounds.y + halfVertCamera, maxBounds.y - halfVertCamera);
        clampedPosition.z = -1f; 
        // applies the clamped position to the camera
        transform.position = clampedPosition;
    }

    Vector3 GetTargetPosition()
    {
        return targetEntity.position; 
    }

    
   
}

