using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShunpoBar : MonoBehaviour {

    float maxWidth;
    KatarinaShunpo katSlow;
    RectTransform rectTransform;

    void Start() {
        katSlow = Katarina.instance.GetComponent<KatarinaShunpo>();
        rectTransform = GetComponent<RectTransform>();
        maxWidth = rectTransform.sizeDelta.x;
    }

    void Update() {
        float currentWidth = katSlow.cooldown / katSlow.cooldownTime * maxWidth;
        rectTransform.sizeDelta = new Vector2(currentWidth, rectTransform.sizeDelta.y);
    }
}
