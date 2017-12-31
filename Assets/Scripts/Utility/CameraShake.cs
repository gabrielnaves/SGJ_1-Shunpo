using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    static public CameraShake instance { get; private set; }

    bool active;
    float shakeTime;
    float elapsedTime;

    void Awake() {
        instance = this;
    }

    public void Activate(float time = 0.2f) {
        shakeTime = time;
        elapsedTime = 0;
        active = true;
    }

    void Update() {
        if (active) {
            elapsedTime += Time.unscaledDeltaTime;
            transform.position = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), -10);
            if (elapsedTime > shakeTime)
                active = false;
        }
        else
            transform.position = new Vector3(0, 0, -10);
    }
}
