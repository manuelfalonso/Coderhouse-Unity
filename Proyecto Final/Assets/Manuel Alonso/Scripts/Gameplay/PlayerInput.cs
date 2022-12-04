using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Data")]
    public float velocidad = 5f;
    public float velocidadRotacion = 1f;

    [Header("Input")]
    public KeyCode rotateRight = KeyCode.E;
    public KeyCode rotateLeft = KeyCode.Q;

    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 translation = new Vector3(moveHorizontal, 0f, moveVertical) * velocidad * Time.deltaTime;

        transform.Translate(translation, Space.Self);
    }

    private void Rotate()
    {
        if (Input.GetKey(rotateRight))
        {
            transform.Rotate(Vector3.up, velocidadRotacion);
        }

        if (Input.GetKey(rotateLeft))
        {
            transform.Rotate(Vector3.up, -velocidadRotacion);
        }
    }
}
