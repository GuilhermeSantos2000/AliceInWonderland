using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject objectToTeleport; // Objeto a ser teletransportado
    [SerializeField] private Transform teleportTarget;    // Objeto alvo para onde o objeto será teletransportado

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que recebeu este script está a colidir com o trigger de teletransporte
        if (collision.gameObject == objectToTeleport)
        {
            // Teleport o objeto para a ser teletransportado para a posição do alvo
            if (teleportTarget != null)
            {
                objectToTeleport.transform.position = teleportTarget.position;
            }
        }
    }
}
