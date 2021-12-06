using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Variables
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private float weight;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        //controller.
        // is the controller on the ground?
        //if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        //controller.Move(moveDirection * Time.deltaTime);
        transform.position += moveDirection * Time.deltaTime;
    }

    public bool OnGround()
    {
        return true; // controller.isGrounded;
    }

    public void AddWeight(float w)
    {
        weight += w;
    }
}
