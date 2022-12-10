using UnityEngine;
using Cinemachine;

public class Respawn : MonoBehaviour
{
    public float timeToRespawn = 3f;

    [Header("Cameras")]
    [SerializeField] private CinemachineVirtualCamera _spawnCamera = default;
    [SerializeField] private CinemachineVirtualCamera _playerCamera = default;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private float timeSinceDeath = 0f;
    private bool isCounterActive = false;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        ToggleCamera();
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
        ToggleCamera();
    }

    public void StartCountdown()
    {
        isCounterActive = true;
        ToggleCamera();
        Debug.Log($"Respawning in {timeToRespawn} seconds");
    }

    private void ToggleCamera()
    {
        if (_spawnCamera != null)
            _spawnCamera.gameObject.SetActive(!_spawnCamera.gameObject.activeSelf);

        if (_playerCamera != null)
            _playerCamera.gameObject.SetActive(!_playerCamera.gameObject.activeSelf);
    }
}
