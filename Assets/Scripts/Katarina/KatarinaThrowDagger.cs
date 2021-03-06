﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatarinaThrowDagger : MonoBehaviour {

    public GameObject daggerPrefab;
    public float cooldownTime = 1f;
    public float cooldown = 0;
    public float daggerVelocity = 20f;

    void Update() {
        cooldown += Time.unscaledDeltaTime;
        if (cooldown > cooldownTime && DaggerCount.instance.currentDaggers > 0) {
            if (GameInput.GetAxisDown(InputAxis.DaggerThrow))
                ThrowDagger(Camera.main.ScreenToWorldPoint(GameInput.mousePosition) - transform.position);
            if (GameInput.GetAxisDown(InputAxis.Preparation))
                ThrowDagger(Vector2.up, preparation:true);
        }
    }

    void ThrowDagger(Vector2 launchVector, bool preparation=false) {
        cooldown = 0;
        var dagger = Instantiate(daggerPrefab);
        dagger.transform.position = transform.position + (Vector3)(launchVector.normalized * 0.27f);
        dagger.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(launchVector.y, launchVector.x) * Mathf.Rad2Deg - 90);
        dagger.GetComponent<Rigidbody2D>().velocity = launchVector.normalized * (preparation ? daggerVelocity * 0.75f : daggerVelocity);
        DaggerCount.instance.ThrewDagger();
        if (preparation)
            dagger.GetComponent<Damage>().enabled = false;
    }
}
