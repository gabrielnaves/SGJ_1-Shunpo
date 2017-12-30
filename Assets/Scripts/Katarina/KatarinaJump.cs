using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatarinaJump : MonoBehaviour {

    public float jumpSpeed = 10f;
    public float maxJumpHeight = 4f;

    float startingHeight;
    Rigidbody2D rigidbody2d;
    Groundcheck groundcheck;
    Animator animator;
    bool jumping;

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        groundcheck = GetComponentInChildren<Groundcheck>();
        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate() {
        if (!jumping && groundcheck.onGround && GameInput.GetAxis(InputAxes.jump) == 1) {
            jumping = true;
            startingHeight = transform.position.y;
            animator.SetTrigger("jumped");
        }
        else if (jumping) {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpSpeed);
            if (GameInput.GetAxis(InputAxes.jump) != 1 || transform.position.y - startingHeight > maxJumpHeight) {
                jumping = false;
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpSpeed / 2);
                animator.SetTrigger("endedJump");
            }
        }
    }
}
