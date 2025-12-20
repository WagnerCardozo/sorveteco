using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distanceFromTarget = 10f;

    [SerializeField] float sensitivity = 100f;

    private float yaw = -45f;
    private float pitch = 30f;

    void Update()
    {
        HandleInput();
        Quaternion yawRotation = Quaternion.Euler(pitch, yaw, 0f);
        RotateCamera(yawRotation);
    }

    public void HandleInput()
    {
        Vector2 inputDelta = Vector2.zero;
        if (Input.GetMouseButton(0))
        {
            inputDelta = new Vector2(Input.GetAxis("Mouse X"), 0);
        }

        yaw += inputDelta.x * sensitivity * Time.deltaTime;
        pitch += inputDelta.y * sensitivity * Time.deltaTime;
    }


    void RotateCamera(Quaternion rotation)
    {
        Vector3 positionOffset = rotation * new Vector3(0, 0, -distanceFromTarget);
        transform.position = target.position + positionOffset;
        transform.rotation = rotation;
    }
}
