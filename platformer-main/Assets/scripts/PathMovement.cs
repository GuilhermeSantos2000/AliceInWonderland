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

        Vector3 targetPoint = staticPositions[currentPointIndex];
        Vector3 direction = (targetPoint - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;

        // Check if close enough to the target point
        if (Vector3.Distance(transform.position, targetPoint) < reachThreshold)
        {
            transform.position = targetPoint; // Snap to the point
            currentPointIndex = (currentPointIndex + 1) % staticPositions.Length;
        }
    }
}