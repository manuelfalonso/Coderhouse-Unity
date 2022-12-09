using System;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed = 1f;
    [SerializeField] private float _verticalSpeed = 1f;

    [SerializeField] private bool _horizontalRotate = false;
    [SerializeField] private bool _verticallRotate = false;

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (_horizontalRotate)
        {
            horizontalInput = Input.GetAxis("Mouse X") * Time.deltaTime * _horizontalSpeed;
        }

        if (_verticallRotate)
        {
            verticalInput = Input.GetAxis("Mouse Y") * Time.deltaTime * _verticalSpeed;
        }

        transform.Rotate(verticalInput, horizontalInput, 0f);
    }
}
