using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katarina : MonoBehaviour {

    static public Katarina instance { get; private set; }

    public float gravityScale = 6;
    public float killCDReduction = 5f;

    void Awake() {
        if (instance)
            Debug.LogError("Multiple instances of katarina");
        instance = this;
    }
}
