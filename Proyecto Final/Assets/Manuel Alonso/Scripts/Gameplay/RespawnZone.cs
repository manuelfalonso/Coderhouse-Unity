using UnityEngine;

public class RespawnZone : MonoBehaviour
{
    [Header("Player")]
    public string playerTag;

    [Header("Enemy")]
    public string enemyTag;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag) && !other.CompareTag(enemyTag))
            return;

        if (other.TryGetComponent<Respawn>(out Respawn component))
        {
            component.StartCountdown();
        }
    }
}
