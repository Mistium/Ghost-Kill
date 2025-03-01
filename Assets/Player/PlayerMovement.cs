using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    Boolean canMove = true;

    CharacterController CC;

    Vector3 moveDirection;
    Vector3 lastMove = new Vector3(0,0,0);

    public float moveSpeed = 5f;
    public float accelerationSpeed = 50f;
    

    void Start()
    {
        CC = GetComponent<CharacterController>();
        //to make sure player doesnt clip into floor
        CC.Move(new Vector3(0, 1, 0));
    }


    void Update()
    {
        //so player control can be disabled for cutscenes and transitions.
        if (canMove) {
            //get input direction, assign to movement vector
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            //for acceleration/decceleration, lerp between moveDirection and the moveDirection from last frame. also multiply by move speed for fun.
            moveDirection = Vector3.Lerp(lastMove, moveDirection, accelerationSpeed).normalized * moveSpeed;
            CC.Move(moveDirection);

            //for acceleration/deceleration
            lastMove = moveDirection;
        }
        //apply harsh gravity when in air, player should always be on ground
        if (!CC.isGrounded)
        {
            CC.Move(new Vector3(0, -2, 0));
        }
    }

    public void toggleMovement(bool input)
    {
        canMove = input;
    }
}
