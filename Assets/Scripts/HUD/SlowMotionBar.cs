using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMotionBar : MonoBehaviour {

    float maxWidth;
    KatarinaSlowMotion katSlow;
    RectTransform rectTransform;

    void Start() {
        katSlow = Katarina.instance.GetComponent<KatarinaSlowMotion>();
        rectTransform = GetComponent<RectTransform>();
        maxWidth = rectTransform.sizeDelta.x;
    }

    void Update() {
        float currentWidth = katSlow.slowMotionTime / katSlow.maxSlowMotionTime * maxWidth;
        rectTransform.sizeDelta = new Vector2(currentWidth, rectTransform.sizeDelta.y);
    }
}
