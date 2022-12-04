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
            // Create explosion
            collision.gameObject.GetComponent<Rigidbody>().
                AddExplosionForce(explosionForce, collision.contacts[0].point, explosionRadius, 0f, ForceMode.Impulse);
            // Play sound
            AudioManager.Instance.PlaySound(_clip);
            Destroy(gameObject);
        }
    }
}
