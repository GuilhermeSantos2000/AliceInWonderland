
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private Transform targetEntity;
    [SerializeField] private Vector3 offset; 
    [SerializeField] private float maxspeed;
    [SerializeField] private float pandown;

    [SerializeField] private Vector2 minBounds; 
    [SerializeField] private Vector2 maxBounds; 

   
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
            transform.position = currentTarget; // this will snap the camera back to the target if it is too far away (currently set to 400f)
        }
        else
        {
            transform.position = Vector3.MoveTowards (transform.position, currentTarget, maxspeed * Time.fixedDeltaTime); // tis moves the camera towards the target defined
        }
    }

    void LateUpdate()
    {
        Vector3 clampedPosition = transform.position;

        // Limitar a posição da câmera nos eixos X e Y
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBounds.x, maxBounds.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minBounds.y, maxBounds.y);

        // Aplicar a posição limitada
        transform.position = clampedPosition;
    }

    Vector3 GetTargetPosition()
    {
        return targetEntity.position; // this will get the target position
    }

    
   
}

