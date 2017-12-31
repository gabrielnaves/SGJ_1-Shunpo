using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    static public EnemySpawner instance { get; private set; }

    public float waveTime = 10f;
    public float elapsedTime;
    public int waveCount;

    public float startingWaveTime;

    public float timeToNextWave {
        get {
            if (OnWave()) return -1f;
            return waveTime - elapsedTime;
        }
    }

    ArcherSpawner archerSpawner;
    SwordsmanSpawner swordsmanSpawner;

    void Awake() {
        instance = this;
        archerSpawner = GetComponentInChildren<ArcherSpawner>();
        swordsmanSpawner = GetComponentInChildren<SwordsmanSpawner>();
        startingWaveTime = waveTime;
    }

    void Update() {
        elapsedTime += Time.unscaledDeltaTime;
        if (elapsedTime > waveTime && !OnWave())
            StartWave();
        if (OnWave())
            elapsedTime = 0f;
    }

    public bool OnWave() {
        return archerSpawner.HasEnemies() || swordsmanSpawner.HasEnemies();
    }

    void StartWave() {
        StartCoroutine(archerSpawner.SpawnWave());
        StartCoroutine(swordsmanSpawner.SpawnWave());
        elapsedTime = 0f;
        waveCount++;
        waveTime = startingWaveTime * (1 - (float)EnemySpawner.instance.waveCount / startingWaveTime);
        if (waveTime < 0) waveTime = 0;
    }
}
