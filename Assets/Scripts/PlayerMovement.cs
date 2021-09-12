using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float climbSpeed;

    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    private bool isOnWall;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallMask;

    private CharacterController controller;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(0, 0, moveZ * walkSpeed);

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
        isOnWall = Physics.CheckSphere(wallCheck.position, 0.9f, wallMask);
        if (isOnWall)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection = new Vector3(0, climbSpeed, 0);
            }
        }

        if (moveDirection != Vector3.zero)
        {
            if (moveDirection.y == 0)
            {
                Walk();
            }
            else
            {
                Climb();
            }
        }
        else
        {
            if (isGrounded)
            {
                Idle();
            }
            else
            {
                FreezeAnimation();
            }
        }

        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Idle()
    {
        anim.speed = 1;
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        anim.speed = 1;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Climb()
    {
        anim.speed = 1;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private void FreezeAnimation()
    {
        anim.speed = 0;
    }
}
