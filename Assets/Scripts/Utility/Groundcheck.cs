using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour {

    public Animator targetAnimator;
    public bool onGround { get; private set; }

    void OnTriggerStay2D(Collider2D other) {
        onGround = true;
        SetAnimatorFlag();
    }

    void OnTriggerExit2D(Collider2D other) {
        onGround = false;
        SetAnimatorFlag();
    }

    void SetAnimatorFlag() {
        if (targetAnimator)
            targetAnimator.SetBool("onGround", onGround);
    }
}
