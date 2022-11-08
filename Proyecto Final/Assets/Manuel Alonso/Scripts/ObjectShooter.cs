using UnityEngine;

public class ObjectShooter : MonoBehaviour
{
    [Header("Data")]
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float shootRate = 1f;
    public bool isAutomatic = false;

    [Header("Input")]
    public KeyCode fireButton = KeyCode.Space;

    private float timeToShoot;

    private void Update()
    {
        PrepareShooting();
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
    }
}
