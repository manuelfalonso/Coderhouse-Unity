using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Data")]
    public Vector3 direction;
    public float speed;
    public float damage;
    public float timeToDestroy;

    [Header("Explosion")]
    public float explosionForce = 10f;
    public float explosionRadius = 1f;
    public int entitiesLayer = 6;
    [SerializeField] private AudioClip _clip;

    private Rigidbody rb;

    private float _baseExplosionForce = 1f;

    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == entitiesLayer)
        {
            if (collision.gameObject.TryGetComponent(out TotalDamage component))
            {
                float totalDamage = component.GetHit();

                // Create explosion
                collision.gameObject.GetComponent<Rigidbody>().
                    AddExplosionForce(_baseExplosionForce + explosionForce * totalDamage, collision.contacts[0].point, explosionRadius, 10f, ForceMode.Impulse);
            }
        }

        // Play sound
        AudioManager.Instance.PlaySound(_clip);
        Destroy(gameObject);
    }
}
