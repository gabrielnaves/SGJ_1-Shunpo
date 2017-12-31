using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerCount : MonoBehaviour {

    static public DaggerCount instance { get; private set; }

    public int maxDaggers;
    public int currentDaggers;

    public void ThrewDagger() {
        currentDaggers--;
    }

    public void CollectedDagger() {
        currentDaggers++;
        if (currentDaggers > maxDaggers)
            currentDaggers = maxDaggers;
    }

    void Awake() {
        instance = this;
        currentDaggers = maxDaggers;
    }
}
