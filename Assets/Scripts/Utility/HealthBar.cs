using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    HitPoints hitPoints;
    float maxWidth;
    RectTransform rectTransform;

    public void SetHitPoints(HitPoints hp) {
        hitPoints = hp;
    }

    void Start() {
        rectTransform = GetComponent<RectTransform>();
        maxWidth = rectTransform.sizeDelta.x;
    }

    void Update() {
        float currentWidth = (float)hitPoints.hitpoints / (float)hitPoints.startingHitpoints * maxWidth;
        rectTransform.sizeDelta = new Vector2(currentWidth, rectTransform.sizeDelta.y);
    }
}
