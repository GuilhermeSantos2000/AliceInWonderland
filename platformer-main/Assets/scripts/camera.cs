using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private Transform targetEntity;
    [SerializeField] private Vector3 offset; 
    [SerializeField] private float maxspeed;
    [SerializeField] private float pandown;

   
    void Start()
    {
        
    }

    
    void  FixedUpdate()
    {

        Vector3 currentTarget = GetTargetPosition(); 
        currentTarget.z = transform.position.z; // this keeps the camera from moving on the z axis
        currentTarget = currentTarget + offset; // offset in case we wanna use it later

        if (Vector3.Distance(transform.position, currentTarget) > 200f)
        {
            transform.position = currentTarget; // this will snap the camera back to the target if it is too far away (currently set to 200f)
        }
        else
        {
            transform.position = Vector3.MoveTowards (transform.position, currentTarget, maxspeed * Time.fixedDeltaTime); // tis moves the camera towards the target defined
        }
      
        
    }

    Vector3 GetTargetPosition()
    {
        return targetEntity.position; // this will get the target position
    }
   
}

