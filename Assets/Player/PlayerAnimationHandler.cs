using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animator;
    Vector3 v3Velocity;
    Vector3 lastPos;
    void Start()
    {
        animator = GetComponent<Animator>();
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = transform.position - lastPos;

        // using 2d symantics

        animator.SetFloat("Xv", velocity.x * 100);
        animator.SetFloat("Yv", velocity.z * 99);
        lastPos = transform.position;
    }
}
