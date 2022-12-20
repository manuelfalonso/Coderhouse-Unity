using UnityEngine;
using UnityEngine.Events;

public class AIBehaviour : MonoBehaviour
{
    // Public variables
    public BehaviourState comportamientoEnemigo;

    public Transform _target;

    public float chaseSpeed;
    public float lookAtSpeed;
    public float chaseMinDistance;

    [Header("Events")]
    public UnityEvent<bool> OnIsMovingChanged = new UnityEvent<bool>();

    // Protected variables
    protected Rigidbody rb;

    [SerializeField]
    protected bool targetOnRange = false;
    protected Vector3 _lastPosition = new Vector3();

    protected bool _isMoving = false;
    public bool IsMoving
    {
        get { return _isMoving; }
        set
        {
            if (_isMoving != value)
            {
                _isMoving = value;
                OnIsMovingChanged?.Invoke(value);
            }
        }
    }

    public enum BehaviourState
    {
        None = 0,
        LookAtTarget,
        ChaseTarget
    }

    virtual protected void Start()
    {
        rb = GetComponent<Rigidbody>();
        _lastPosition = transform.position;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
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

        CheckIsMoving();
    }

    private void CheckIsMoving()
    {
        if (_lastPosition == transform.position)
        {
            IsMoving = false;
        }
        else
        {
            IsMoving = true;
        }

        _lastPosition = transform.position;
    }

    private void LookAtTarget()
    {
        Vector3 relativePos = _target.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(relativePos);
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
        Vector3 newPosition = transform.position + chaseSpeed * Time.deltaTime * direction;
        rb.MovePosition(newPosition);
    }
}
