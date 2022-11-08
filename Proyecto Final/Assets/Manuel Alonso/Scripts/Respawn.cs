using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float timeToRespawn = 3f;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private float timeSinceDeath = 0f;
    private bool isCounterActive = false;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        CheckCountdown();
    }

    private void CheckCountdown()
    {
        if (!isCounterActive)
            return;

        timeSinceDeath += Time.deltaTime;

        if (timeSinceDeath >= timeToRespawn)
        {
            isCounterActive = false;
            timeSinceDeath = 0f;

            RespawnObject();
        }
    }

    private void RespawnObject()
    {
        Debug.Log($"Respawned");
        transform.position = startPosition;
        transform.rotation = startRotation;
    }

    public void StartCountdown()
    {
        isCounterActive = true;
        Debug.Log($"Respawning in {timeToRespawn} seconds");
    }
}
