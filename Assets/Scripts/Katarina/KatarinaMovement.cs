using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatarinaMovement : MonoBehaviour {

    public float accel = 1f;

    Rigidbody2D rigidbody2d;
    Animator animator;

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        float input = Input.GetAxis(InputAxes.horizontal);
        if (!Mathf.Approximately(input, 0)) {
            rigidbody2d.velocity = new Vector2(accel * input, rigidbody2d.velocity.y);
            if (input > 0)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (input < 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("moving", true);
        }
        else
            animator.SetBool("moving", false);
    }
}
