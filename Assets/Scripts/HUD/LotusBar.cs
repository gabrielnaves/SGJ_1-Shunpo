using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotusBar : MonoBehaviour {

    float maxWidth;
    KatarinaDeathLotus katLotus;
    RectTransform rectTransform;

    void Start() {
        katLotus = Katarina.instance.GetComponentInChildren<KatarinaDeathLotus>();
        rectTransform = GetComponent<RectTransform>();
        maxWidth = rectTransform.sizeDelta.x;
    }

    void Update() {
        float currentWidth = katLotus.cooldown / katLotus.cooldownTime * maxWidth;
        rectTransform.sizeDelta = new Vector2(currentWidth, rectTransform.sizeDelta.y);
    }
}
