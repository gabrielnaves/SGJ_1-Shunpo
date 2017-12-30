using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatarinaSlowMotion : MonoBehaviour {

    public float cooldownTime = 3f;
    float cooldown;

    void Update() {
        cooldown += Time.deltaTime;
        if (Input.GetAxis(InputAxes.slowMotion) != 0 && cooldown > cooldownTime) {
            cooldown = cooldownTime;
            SlowMotion.instance.Activate();
        }
    }
}
