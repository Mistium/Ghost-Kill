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
    public float cameraXOffset = 1.5f;
    public float cameraCollisionOffset = 0.2f;
    public float minCameraHeight = 0.5f; // Minimum height for the camera
    public float heightAdjustmentRate = 0.5f; // How quickly height adjusts based on distance
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
            moveDirection = Vector3.Lerp(lastMove, moveDirection, accelerationSpeed).normalized * moveSpeed * Time.deltaTime * 100;
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
        // Calculate ideal camera position with X offset
        Vector3 cameraOffset = -transform.forward * cameraDistance + transform.right * cameraXOffset;
        Vector3 idealPosition = transform.position + cameraOffset;
        idealPosition.y += cameraHeight;

        // Perform collision check
        RaycastHit hit;
        float actualDistance = cameraDistance;
        Vector3 startPoint = transform.position + Vector3.up * (cameraHeight * 0.5f);

        if (Physics.Linecast(startPoint, idealPosition, out hit, collisionLayers))
        {
            actualDistance = Vector3.Distance(startPoint, hit.point) - cameraCollisionOffset;

            // Recalculate position with new distance
            cameraOffset = -transform.forward * actualDistance + transform.right * cameraXOffset;
            idealPosition = startPoint + cameraOffset;
        }

        // Calculate dynamic height based on distance - lower height when closer
        float distanceRatio = actualDistance / cameraDistance; // 1 at max distance, lower when closer
        float dynamicHeight = Mathf.Lerp(minCameraHeight, cameraHeight, distanceRatio);

        // Apply the dynamic height
        Vector3 finalPosition = idealPosition;
        finalPosition.y = transform.position.y + dynamicHeight;

        // Apply collision offset if we hit something
        if (Physics.Linecast(startPoint, finalPosition, out hit, collisionLayers))
        {
            finalPosition = hit.point + hit.normal * cameraCollisionOffset;
        }

        // Set camera position
        cameraTransform.position = finalPosition;

        // Look at player's upper body rather than feet
        float lookHeight = Mathf.Lerp(0.8f, 1.5f, distanceRatio); // Look lower when camera is closer
        cameraTransform.LookAt(transform.position + Vector3.up * lookHeight);
    }

    public void toggleMovement(bool input)
    {
        canMove = input;
    }
}