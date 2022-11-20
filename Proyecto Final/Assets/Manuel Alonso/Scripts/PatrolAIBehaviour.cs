using UnityEngine;

public class PatrolAIBehaviour : AIBehaviour
{
    [Header("Waypoints")]
    public Vector3[] waypoints;

	private Vector3[] newWaypoints;
    private int currentTargetIndex;

    protected void Start()
    {
        base.Start();

        InitializeWaypoints();
    }

    private void InitializeWaypoints()
    {
        currentTargetIndex = 0;

        newWaypoints = new Vector3[waypoints.Length + 1];
        for (int i = 0; i < waypoints.Length; i++)
        {
            newWaypoints[i] = waypoints[i];
        }

        newWaypoints[waypoints.Length] = transform.position;
    }

    void FixedUpdate()
    {
        if (targetOnRange == false)
            Patrol();
    }

    private void Patrol()
    {
        Vector3 currentTarget = newWaypoints[currentTargetIndex];

        rb.MovePosition(
            transform.position +
            (currentTarget - transform.position).normalized
            * chaseSpeed
            * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, currentTarget) <= .1f)
        {
            // Waypoint has been reached
            if (currentTargetIndex == newWaypoints.Length - 1)
            {
                currentTargetIndex = 0;
            }
            else
            {
                currentTargetIndex++;
            }

            // Orient to direction ??
        }
    }
}
