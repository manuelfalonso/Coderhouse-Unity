using System;
using UnityEngine;
using UnityEngine.UI;

public class ObjectShooter : MonoBehaviour
{
    [Header("Data")]
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float shootRate = 1f;
    public bool isAutomatic = false;

    [Header("Input")]
    public KeyCode fireButton = KeyCode.Space;

    [Header("UI")]
    public Image CannonCharge;

    [Header("Sound")]
    [SerializeField] private AudioClip _shootClip = default;

    private float timeToShoot;

    private void Update()
    {
        PrepareShooting();
        CannonChargeBar();
    }

    private void CannonChargeBar()
    {
        if (CannonCharge == null)
            return;

        CannonCharge.fillAmount = 1 / (shootRate / timeToShoot);
    }

    private void PrepareShooting()
    {
        if (spawnPoint == null)
            return;

        timeToShoot += Time.deltaTime;

        if (timeToShoot <= shootRate)
            return;

        if (isAutomatic)
        {
            Shoot();
            timeToShoot = 0f;
        }
        else if (Input.GetKeyDown(fireButton))
        {
            Shoot();
            timeToShoot = 0f;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        // Play sound
        AudioManager.Instance.PlaySound(_shootClip);
    }
}
