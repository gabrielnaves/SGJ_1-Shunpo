using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatarinaJump : MonoBehaviour {

    public float jumpSpeed = 10f;
    public float maxJumpHeight = 4f;
    public float minJumpHeight = 2f;

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
        if (!jumping && groundcheck.onGround && GameInput.GetAxisDown(InputAxes.jump))
            Jump();
        else if (jumping) {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpSpeed);
            if (ShouldEndJump()) {
                jumping = false;
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpSpeed / 2);
                animator.SetTrigger("endedJump");
            }
        }
    }

    public void Jump() {
        jumping = true;
        startingHeight = transform.position.y;
        animator.SetTrigger("jumped");
    }

    bool ShouldEndJump() {
        return (GameInput.GetAxis(InputAxes.jump) != 1 || transform.position.y - startingHeight > maxJumpHeight)
               && transform.position.y - startingHeight > minJumpHeight;
    }
}
