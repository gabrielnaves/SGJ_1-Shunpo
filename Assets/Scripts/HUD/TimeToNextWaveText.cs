using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeToNextWaveText : MonoBehaviour {

    Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    void Update() {
        text.text = "Time to next wave: ";
        if (EnemySpawner.instance.OnWave())
            text.text += "--";
        else
            text.text += EnemySpawner.instance.timeToNextWave.ToString("0.0");
    }
}
