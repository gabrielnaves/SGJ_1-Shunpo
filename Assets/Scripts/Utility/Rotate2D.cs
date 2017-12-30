using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2D : MonoBehaviour {

    public float velocity;

    Rigidbody2D rigidbody2d;

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (rigidbody2d)
            rigidbody2d.angularVelocity = velocity;
        else {
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.z += velocity * Time.deltaTime;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
