using UnityEngine;

public class ObserverAIBehaviour : AIBehaviour
{
	private float currentRotation;

    void FixedUpdate()
    {
        if (targetOnRange == false)
            Observe();
    }

    private void Observe()
    {
        // Create a rotation
        currentRotation += lookAtSpeed * Time.fixedDeltaTime;

        // Apply the rotation to the Rigidbody
        var newRotation = Quaternion.Euler(new Vector3(
            transform.rotation.x,
            currentRotation,
            transform.rotation.z));
        rb.MoveRotation(newRotation);
    }
}
