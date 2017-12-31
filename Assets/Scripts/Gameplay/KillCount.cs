using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCount : MonoBehaviour {

    public static KillCount instance { get; private set; }

    public int kills;

    public void IncreaseCount() {
        kills++;
    }

    void Awake() {
        instance = this;
    }
}
