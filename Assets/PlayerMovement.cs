using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Transform wallCheck;
    public float wallDistance = 0.4f;
    public LayerMask wallMask;

    Vector3 velocity;
    bool isGrounded;
    bool isOnWall;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isOnWall = Physics.CheckSphere(wallCheck.position, wallDistance, wallMask);
        if ((isGrounded || isOnWall )&& velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isOnWall)
        {
            velocity.y = 10f;
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
