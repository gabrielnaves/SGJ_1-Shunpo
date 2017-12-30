﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputAxes {
    horizontal,
    vertical,
    jump,
    daggerThrow,
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
        "Shunpo",
        "SlowMotion"
    };

    float[] lastValues;

    void Awake() {
        if (instance)
            Debug.LogError("Multiple instances of game input");
        instance = this;
        lastValues = new float[axes.Length];
    }

    void LateUpdate() {
        for (int i = 0; i < lastValues.Length; ++i)
            lastValues[i] = Input.GetAxis(axes[i]);
    }

    public static float GetAxis(InputAxes axis) {
        return Input.GetAxis(axes[(int)axis]);
    }

    public static bool GetAxisDown(InputAxes axis) {
        return Input.GetAxis(axes[(int)axis]) == 1 && GameInput.instance.lastValues[(int)axis] == 0;
    }

    public static bool GetAxisUp(InputAxes axis) {
        return Input.GetAxis(axes[(int)axis]) == 0 && GameInput.instance.lastValues[(int)axis] == 1;
    }

    public static Vector3 mousePosition {
        get {
            return Input.mousePosition;
        }
    }
}

