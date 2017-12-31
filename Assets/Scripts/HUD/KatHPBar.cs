using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatHPBar : MonoBehaviour {
    float maxWidth;
    HitPoints katHP;
    RectTransform rectTransform;

    void Start() {
        katHP = Katarina.instance.GetComponent<HitPoints>();
        rectTransform = GetComponent<RectTransform>();
        maxWidth = rectTransform.sizeDelta.x;
    }

    void Update() {
        float currentWidth = (float)katHP.hitpoints / (float)katHP.startingHitpoints * maxWidth;
        rectTransform.sizeDelta = new Vector2(currentWidth, rectTransform.sizeDelta.y);
    }
}
