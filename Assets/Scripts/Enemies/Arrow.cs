using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public LayerMask hitMask;

    bool hit;

    void OnCollisionEnter2D(Collision2D other) {
        if ((hitMask.value & 1 << other.gameObject.layer) != 0 && !hit) {
            GetComponent<Animator>().SetTrigger("hit");
            hit = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
    }
}
