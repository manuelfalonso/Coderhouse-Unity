using UnityEngine;
using Cinemachine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private bool _isPlayer = false;
    public float timeToRespawn = 3f;
    [SerializeField] private int _lifes = 3;
    public int Lifes { get { return _lifes; } set { _lifes = value; } }

    [Header("Cameras")]
    [SerializeField] private CinemachineVirtualCamera _spawnCamera = default;
    [SerializeField] private CinemachineVirtualCamera _playerCamera = default;

    [Space]
    public UnityEvent OnLifeLost = new UnityEvent();
    public UnityEvent<bool> OnDeath = new UnityEvent<bool>();

    private Vector3 startPosition;
    private Quaternion startRotation;
    private float timeSinceDeath = 0f;
    private bool isCounterActive = false;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        ToggleCamera();

        if (!_isPlayer)
        {
            GameManager.Instance.SubscribeTank(this);
        }
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
            OnDeath?.Invoke(_isPlayer);
            if (_isPlayer)
            {
                Invoke(nameof(RestartLevel), 5f);
            }
            else
            {
                Destroy(gameObject, 2f);
            }
        }
    }

    private void ToggleCamera()
    {
        if (_spawnCamera != null)
            _spawnCamera.gameObject.SetActive(!_spawnCamera.gameObject.activeSelf);

        if (_playerCamera != null)
            _playerCamera.gameObject.SetActive(!_playerCamera.gameObject.activeSelf);
    }

    private void RestartLevel()
    {
        // Restart same level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
