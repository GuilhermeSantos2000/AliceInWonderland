using UnityEngine;

public class LoopingPathFollower : MonoBehaviour
{
    public Transform[] pathPoints;   // Assign these in the Inspector
    public float moveSpeed = 5f;     // Speed at which the object moves
    public float reachThreshold = 0.1f; // How close before it "reaches" the point

    private int currentPointIndex = 0;

    void Update()
    {
        if (pathPoints.Length == 0)
            return;

        Transform targetPoint = pathPoints[currentPointIndex];
        Vector3 direction = (targetPoint.position - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;

        // Check if close enough to the target point
        if (Vector3.Distance(transform.position, targetPoint.position) < reachThreshold)
        {
            currentPointIndex = (currentPointIndex + 1) % pathPoints.Length;
        }
    }
}