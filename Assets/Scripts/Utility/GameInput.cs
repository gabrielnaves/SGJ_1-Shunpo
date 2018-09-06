using UnityEngine;

public enum InputAxis {
    Horizontal,
    Vertical,
    Jump,
    DaggerThrow,
    Preparation,
    Shunpo,
    DeathLotus,
    SlowMotion
}

public static class GameInput {

    public static int GetAxis(InputAxis axis) {
        return (int)Mathf.Ceil(Input.GetAxis(axis.ToString()));
    }

    public static bool GetAxisDown(InputAxis axis) {
        return Input.GetButtonDown(axis.ToString());
    }

    public static bool GetAxisUp(InputAxis axis) {
        return Input.GetButtonUp(axis.ToString());
    }

    public static Vector3 mousePosition {
        get {
            return Input.mousePosition;
        }
    }
}

