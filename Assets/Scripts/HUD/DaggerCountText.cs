using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaggerCountText : MonoBehaviour {

    Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    void Update() {
        text.text = "Daggers: " + DaggerCount.instance.currentDaggers;
    }
}
