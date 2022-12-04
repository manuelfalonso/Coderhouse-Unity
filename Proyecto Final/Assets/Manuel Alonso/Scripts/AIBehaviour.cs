using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    // Public variables
    public BehaviourState comportamientoEnemigo;

    public Transform _target;

    public float chaseSpeed;
    public float lookAtSpeed;
    public float chaseMinDistance;

    // Protected variables
    protected Rigidbody rb;

    protected bool targetOnRange = false;

    public enum BehaviourState
    {
        None = 0,
        LookAtTarget,
        ChaseTarget
    }

    virtual protected void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (targetOnRange == true)
        {
            switch (comportamientoEnemigo)
            {
                case BehaviourState.LookAtTarget:
                    LookAtTarget();
                    break;
                case BehaviourState.ChaseTarget:
                    ChaseTarget();
                    break;
                default:                
                    break;
            }
        }
    }

    private void LookAtTarget()
    {
        Vector3 relativePos = _target.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(relativePos);
        //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, lookAtSpeed * Time.deltaTime);
        Quaternion lerpRotation = Quaternion.Lerp(transform.rotation, newRotation, lookAtSpeed * Time.deltaTime);
        rb.MoveRotation(lerpRotation);
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
        //transform.position = transform.position + direction * chaseSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + chaseSpeed * Time.deltaTime * direction;
        rb.MovePosition(newPosition);
    }
}
