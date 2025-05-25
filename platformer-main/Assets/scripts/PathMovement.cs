using UnityEngine;

public class LoopingPathFollower : MonoBehaviour
{
    public Transform[] pathPoints;   // Assign these in the Inspector
    public float moveSpeed = 5f;     // Speed at which the object moves
    public float reachThreshold = 0.1f; // How close before it "reaches" the point

    private int currentPointIndex = 0;
    private Vector3[] staticPositions; // Store initial positions

    void Start()
    {
        // Store the initial positions of the path points
        staticPositions = new Vector3[pathPoints.Length];
        for (int i = 0; i < pathPoints.Length; i++)
        {
            staticPositions[i] = pathPoints[i].position;
        }
    }

    void Update()
    {
        if (staticPositions == null || staticPositions.Length == 0)
            return;

        while (true)
        {
            Vector3 targetPoint = staticPositions[currentPointIndex];
            Vector3 direction = (targetPoint - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, targetPoint);

            if (distance < reachThreshold)
            {
                transform.position = targetPoint;
                currentPointIndex = (currentPointIndex + 1) % staticPositions.Length;
                // Continue the loop in case we're still within reachThreshold of the next point
            }
            else
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
                break;
            }
        }
    }
}