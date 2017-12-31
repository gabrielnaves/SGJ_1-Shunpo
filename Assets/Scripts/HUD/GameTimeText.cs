using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeText : MonoBehaviour {

    Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    void Update() {
        float timer = GameOver.instance.gameTime;
        text.text = "Time left: " + string.Format("{0}:{1:00}", (int)timer / 60, (int)timer % 60);
    }
}
