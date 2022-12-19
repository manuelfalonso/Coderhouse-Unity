using System;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float _horizontalSpeed = 1f;
    [SerializeField] private float _verticalSpeed = 1f;
    [Header("Configuration")]
    [SerializeField] private bool _horizontalRotate = false;
    [SerializeField] private bool _verticallRotate = false;
    [Header("Clamp")]
    [SerializeField] private float _verticalFromAngle = -10f;
    [SerializeField] private float _verticalToAngle = 10f;

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

        // Clamp Rotation
        //transform.Rotate(verticalInput, horizontalInput, 0f);
        Vector3 rotation = transform.rotation.eulerAngles + new Vector3(verticalInput, horizontalInput, 0f);
        rotation.x = ClampAngle(rotation.x, -9f, 9f);
        transform.eulerAngles = rotation;
    }

    float ClampAngle(float angle, float from, float to)
    {
        // accepts e.g. -80, 80
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }
}
