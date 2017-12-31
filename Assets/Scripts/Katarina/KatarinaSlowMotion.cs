using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatarinaSlowMotion : MonoBehaviour {

    public float maxSlowMotionTime = 10f;
    public float slowMotionTime;

    void Start() {
        slowMotionTime = maxSlowMotionTime;
    }

    void Update() {
        CheckSlowMotion();
    }

    void LateUpdate() {
        CheckSlowMotion();
    }

    void CheckSlowMotion() {
        var slowMotion = SlowMotion.instance;
        if (slowMotion.isActive) {
            slowMotionTime -= Time.unscaledDeltaTime;
            if (GameInput.GetAxisUp(InputAxes.slowMotion) || slowMotionTime < 0)
                slowMotion.Deactivate();
        }
        else {
            slowMotionTime += Time.unscaledDeltaTime;
            if (slowMotionTime > maxSlowMotionTime) slowMotionTime = maxSlowMotionTime;
            if (GameInput.GetAxisDown(InputAxes.slowMotion))
                slowMotion.Activate();
        }
    }
}
