using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatarinaSlowMotion : MonoBehaviour {

    public float maxSlowMotionTime = 10f;
    public float slowMotionTime;

    float lastAxisValue;

    void Start() {
        slowMotionTime = maxSlowMotionTime;
        lastAxisValue = Input.GetAxis(InputAxes.slowMotion);
    }

    void Update() {
        var slowMotion = SlowMotion.instance;
        if (slowMotion.isActive) {
            slowMotionTime -= Time.unscaledDeltaTime;
            if (AxisUp() || slowMotionTime < 0)
                slowMotion.Deactivate();
        }
        else {
            slowMotionTime += Time.unscaledDeltaTime;
            if (slowMotionTime > maxSlowMotionTime) slowMotionTime = maxSlowMotionTime;
            if (AxisDown() && slowMotionTime > maxSlowMotionTime / 2)
                slowMotion.Activate();
        }
        lastAxisValue = Input.GetAxis(InputAxes.slowMotion);
    }

    bool AxisUp() {
        return Input.GetAxis(InputAxes.slowMotion) == 0 && lastAxisValue == 1;
    }

    bool AxisDown() {
        return Input.GetAxis(InputAxes.slowMotion) == 1 && lastAxisValue == 0;
    }
}
