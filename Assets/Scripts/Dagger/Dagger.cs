using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour {

    public float ricochetVelocity = 10f;
    public float gravityScale;
    public float angularVelocity;

    bool firstHit;

    void OnCollisionEnter2D(Collision2D other) {
        if (!firstHit) {
            var rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity = new Vector2(0, ricochetVelocity);
            rigidbody.angularVelocity = angularVelocity * 1000f;
            rigidbody.gravityScale = gravityScale;
            firstHit = true;
        }
    }
}
