using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float power = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerInput>(out PlayerInput component))
        {
            component.velocidad *= power;
            Destroy(gameObject);
        }
    }
}
