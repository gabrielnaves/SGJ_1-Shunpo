﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    static public EnemySpawner instance { get; private set; }

    public float waveTime = 10f;
    public float elapsedTime;

    ArcherSpawner archerSpawner;

    void Awake() {
        instance = this;
        archerSpawner = GetComponentInChildren<ArcherSpawner>();
    }

    void Update() {
        elapsedTime += Time.unscaledDeltaTime;
        if (elapsedTime > waveTime && !OnWave()) {
            archerSpawner.SpawnWave();
            elapsedTime = 0f;
        }
        if (OnWave())
            elapsedTime = 0f;
    }

    public bool OnWave() {
        return !archerSpawner.NoEnemies();
    }
}