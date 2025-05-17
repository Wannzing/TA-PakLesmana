using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // The player
    public float mouseSensitivity = 3f;
    public float distance = 8f;
    public float height = 3f;
    public float smoothSpeed = 5f;
    public bool rotatePlayer = true;

    private float currentYaw = 0f;

    void LateUpdate()
    {
        if (target == null) return;

        float mouseX = Input.GetAxis("Mouse X");
        currentYaw += mouseX * mouseSensitivity;

        Quaternion rotation = Quaternion.Euler(0, currentYaw, 0);
        Vector3 desiredPosition = target.position + rotation * new Vector3(0, height, -distance);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.LookAt(target.position + Vector3.up * 1.5f);

        if (rotatePlayer)
        {
            Vector3 lookDirection = transform.forward;
            lookDirection.y = 0;
            if (lookDirection != Vector3.zero)
                target.rotation = Quaternion.Lerp(target.rotation, Quaternion.LookRotation(lookDirection), smoothSpeed * Time.deltaTime);
        }
    }

}
