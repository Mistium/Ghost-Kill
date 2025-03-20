using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Boolean canMove = true;
    CharacterController CC;
    Vector3 moveDirection;
    Vector3 lastMove = new Vector3(0, 0, 0);
    public float moveSpeed = 5f;
    public float accelerationSpeed = 50f;

    // Camera settings
    public Transform cameraTransform;
    public float cameraDistance = 5f;
    public float cameraHeight = 2f;
    public float cameraXOffset = 1.5f; // Added X offset for the camera
    public float cameraCollisionOffset = 0.2f;
    public LayerMask collisionLayers;

    void Start()
    {
        CC = GetComponent<CharacterController>();
        //to make sure player doesnt clip into floor
        CC.Move(new Vector3(0, 1, 0));

        // Initialize camera if not set
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        //so player control can be disabled for cutscenes and transitions.
        if (canMove)
        {
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

        // Update camera position with collision detection
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        // Calculate desired camera position with X offset
        Vector3 cameraOffset = -transform.forward * cameraDistance + transform.right * cameraXOffset;
        Vector3 desiredCameraPos = transform.position + cameraOffset;
        desiredCameraPos.y += cameraHeight;

        // Check for collisions
        RaycastHit hit;
        if (Physics.Linecast(transform.position + Vector3.up * cameraHeight, desiredCameraPos, out hit, collisionLayers))
        {
            // If there's a collision, move the camera to the hit point plus a small offset
            desiredCameraPos = hit.point + hit.normal * cameraCollisionOffset;
        }

        // Apply the new position to the camera
        cameraTransform.position = desiredCameraPos;

        // Always look at the player
        cameraTransform.LookAt(transform.position + Vector3.up);
    }

    public void toggleMovement(bool input)
    {
        canMove = input;
    }
}