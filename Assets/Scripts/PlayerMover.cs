using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float runSpeed = 40f;
    public Animator animator;

    void Start() { }

    void Update()
    {
        Vector2 input = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
            );

        animator.SetBool("IsMoving", input.magnitude > .5);
        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);
    }
}
