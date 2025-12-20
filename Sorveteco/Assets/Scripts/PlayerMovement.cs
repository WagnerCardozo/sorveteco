using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private void FixedUpdate()
    {
        MovePlayerRelativeToCamera();
    }

    void MovePlayerRelativeToCamera()
    {
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        Vector3 foward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        foward.y = 0;
        right.y = 0;
        foward = foward.normalized;
        right = right.normalized;

        Vector3 fowardRelativeVerticalInput = playerVerticalInput * foward;
        Vector3 rightRelativeHorizontalInput = playerHorizontalInput * right;

        Vector3 cameraRelativeMovement = fowardRelativeVerticalInput + rightRelativeHorizontalInput;
        this.transform.Translate(cameraRelativeMovement.normalized * speed * Time.deltaTime, Space.World);
    }
}
