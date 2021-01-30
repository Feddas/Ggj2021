using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    public float runSpeed = .4f;
    public Animator animator;

    private Vector2 input;
    private Rigidbody2D myRigidbody
    {
        get
        {
            if (_rigidbody == null)
            {
                _rigidbody = this.GetComponent<Rigidbody2D>();
            }
            return _rigidbody;
        }
    }
    private Rigidbody2D _rigidbody;

    void Start() { }

    void Update()
    {
        input = new Vector2
        (
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );

        animator.SetBool("IsMoving", input.magnitude > .5);
        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);
    }

    void FixedUpdate()
    {
        myRigidbody.AddForce(input * runSpeed * Time.fixedDeltaTime);
    }
}
