using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour {

    public float timeScale = 0.1f;

    public static SlowMotion instance { get; private set; }
    public bool isActive { get; private set; }

    float elapsedTime;
    float duration;

    public void Activate(float duration = 1f) {
        isActive = true;
        elapsedTime = 0f;
        this.duration = duration;
        Time.timeScale = timeScale;
        Time.fixedDeltaTime *= timeScale;
    }

    public void Deactivate() {
        isActive = false;
        elapsedTime = 0f;
        duration = 0f;
        Time.timeScale = 1f;
        Time.fixedDeltaTime /= timeScale;
    }

    void Awake() {
        if (instance)
            Debug.LogError("Multiple instances of slow motion");
        instance = this;
    }

    void Update() {
        if (isActive) {
            elapsedTime += Time.unscaledDeltaTime;
            if (elapsedTime > duration)
                Deactivate();
        }
    }
}
