using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputAxes {
    horizontal,
    vertical,
    jump,
    daggerThrow,
    preparation,
    shunpo,
    slowMotion
}

public class GameInput : MonoBehaviour {

    static GameInput instance;

    static string[] axes = {
        "Horizontal",
        "Vertical",
        "Jump",
        "DaggerThrow",
        "Preparation",
        "Shunpo",
        "SlowMotion"
    };

    int[] lastValues;

    void Awake() {
        if (instance)
            Debug.LogError("Multiple instances of game input");
        instance = this;
        lastValues = new int[axes.Length];
    }

    void LateUpdate() {
        for (int i = 0; i < lastValues.Length; ++i)
            lastValues[i] = (int)Input.GetAxis(axes[i]);
    }

    public static int GetAxis(InputAxes axis) {
        return (int)Mathf.Ceil(Input.GetAxis(axes[(int)axis]));
    }

    public static bool GetAxisDown(InputAxes axis) {
        return GameInput.GetAxis(axis) == 1 && GameInput.instance.lastValues[(int)axis] == 0;
    }

    public static bool GetAxisUp(InputAxes axis) {
        return GameInput.GetAxis(axis) == 0 && GameInput.instance.lastValues[(int)axis] == 1;
    }

    public static Vector3 mousePosition {
        get {
            return Input.mousePosition;
        }
    }
}

