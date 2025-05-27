using Unity.Mathematics;
using UnityEngine;

public class LoopingPathFollower : MonoBehaviour
{
    public Transform[] pathPoints;   // Assign these in the Inspector
    public float moveSpeed = 5f;     // Speed at which the object moves
    public float reachThreshold = 0.1f; // How close before it "reaches" the point

    private int currentPointIndex = 0;
    private Vector3[] staticPositions; // Store initial positions
    private Vector3 originalScale;

    void Start()
    {
        // Store the initial positions of the path points
        staticPositions = new Vector3[pathPoints.Length];
        for (int i = 0; i < pathPoints.Length; i++)
        {
            staticPositions[i] = pathPoints[i].position;
        }
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (staticPositions == null || staticPositions.Length == 0)
            return;

       
            Vector3 targetPoint = staticPositions[currentPointIndex];
            Vector3 direction = (targetPoint - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, targetPoint);

            if (direction.x < -0.01f)
                transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            else if (direction.x > 0.01f)
                transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);

        if (distance < reachThreshold)
        {
            transform.position = targetPoint;
            currentPointIndex = (currentPointIndex + 1) % staticPositions.Length;
            return;
            // Continue the loop in case we're still within reachThreshold of the next point
        }
          float step = math.min(moveSpeed * Time.deltaTime, distance);
          transform.position += direction * step;  

    }
}