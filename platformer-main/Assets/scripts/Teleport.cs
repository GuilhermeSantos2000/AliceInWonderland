using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject objectToTeleport; // Object to be teleported
    [SerializeField] private Transform teleportTarget;    // Target object for teleportation

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if object receiving this script is colliding with the object to be teleported
        if (collision.gameObject == objectToTeleport)
        {
            // Teleport the object to be teleported to the target position
            if (teleportTarget != null)
            {
                objectToTeleport.transform.position = teleportTarget.position;
            }
        }
    }
}
