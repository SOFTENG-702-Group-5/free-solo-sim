using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;
    float verticalRotation = 0f;
    float horizontalRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsCameraEnabled)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 60f);
            horizontalRotation += mouseX;
            horizontalRotation = Mathf.Clamp(horizontalRotation, -70f, 70f);

            transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
        } else
        {
            verticalRotation = 0;
            horizontalRotation = 0;
        }
    }
}
