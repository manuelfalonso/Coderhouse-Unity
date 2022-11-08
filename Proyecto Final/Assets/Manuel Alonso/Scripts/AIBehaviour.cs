using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    [SerializeField] private ComportamientoEnemigo comportamientoEnemigo;

    public Transform _target;
    public float chaseSpeed;
    public float lookAtSpeed;
    public float chaseMinDistance;

    public enum ComportamientoEnemigo
    {
        LookAtTarget,
        ChaseTarget
    }


    void Update()
    {
        switch (comportamientoEnemigo)
        {
            case ComportamientoEnemigo.LookAtTarget:
                LookAtTarget();
                break;
            case ComportamientoEnemigo.ChaseTarget:
                ChaseTarget();
                break;
            default:
                Debug.LogWarning($"Falta definir comportamiento");
                break;
        }
    }

    private void LookAtTarget()
    {
        Vector3 relativePos = _target.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, lookAtSpeed * Time.deltaTime);
    }

    private void ChaseTarget()
    {
        float distance = (_target.position - transform.position).magnitude;

        if (distance > chaseMinDistance)
        {
            PositionMoveTowards();
        }
    }

    private void PositionMoveTowards()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        transform.position = transform.position + direction * chaseSpeed * Time.deltaTime;
    }
}
