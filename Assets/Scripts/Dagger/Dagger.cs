using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour {

    public float ricochetVelocity = 10f;
    public float angularVelocity;

    [HideInInspector] public float timeSinceInstantiation = 0f;

    bool firstHit;

    void OnCollisionEnter2D(Collision2D other) {
        if (!firstHit) {
            var rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity = new Vector2(0, ricochetVelocity);
            rigidbody.angularVelocity = angularVelocity * 1000f;
            firstHit = true;
        }
    }

    void Update() {
        timeSinceInstantiation += Time.unscaledDeltaTime;
        if (!firstHit)
            LookToMovement();
    }

    void LookToMovement() {
        var velocity = GetComponent<Rigidbody2D>().velocity;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90);
    }
}
