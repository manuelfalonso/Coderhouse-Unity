using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class Respawn : MonoBehaviour
{
    [Header("Data")]
    public float timeToRespawn = 3f;
    [SerializeField] private int _lifes = 3;

    [Header("Cameras")]
    [SerializeField] private CinemachineVirtualCamera _spawnCamera = default;
    [SerializeField] private CinemachineVirtualCamera _playerCamera = default;

    [Space]

    public UnityEvent OnLifeLost = new UnityEvent();
    public UnityEvent OnDeath = new UnityEvent();

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
        ToggleCamera();

        if (_lifes > 0)
        {
            _lifes--;
            OnLifeLost?.Invoke();
            isCounterActive = true;
            Debug.Log($"Respawning in {timeToRespawn} seconds. {_lifes} remaining");
        }
        else
        {
            // Death
            OnDeath?.Invoke();
            Destroy(gameObject, 2f);
            //gameObject.SetActive(false);
        }
    }

    private void ToggleCamera()
    {
        if (_spawnCamera != null)
            _spawnCamera.gameObject.SetActive(!_spawnCamera.gameObject.activeSelf);

        if (_playerCamera != null)
            _playerCamera.gameObject.SetActive(!_playerCamera.gameObject.activeSelf);
    }
}
