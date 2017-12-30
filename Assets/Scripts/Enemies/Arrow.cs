using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public LayerMask hitMask;

    bool hit;
    Vector2 lastMovement;

    void OnCollisionEnter2D(Collision2D other) {
        if ((hitMask.value & 1 << other.gameObject.layer) != 0 && !hit) {
            GetComponent<Animator>().SetTrigger("hit");
            hit = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void Update() {
        if (!hit) {
            LookToMovement(GetComponent<Rigidbody2D>().velocity);
            lastMovement = GetComponent<Rigidbody2D>().velocity;
        }
        else
            LookToMovement(lastMovement);
    }

    void LookToMovement(Vector2 velocity) {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg);
    }
}
