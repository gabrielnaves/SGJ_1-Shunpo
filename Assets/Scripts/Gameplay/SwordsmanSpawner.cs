using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsmanSpawner : MonoBehaviour {

    public GameObject swordsmanPrefab;
    public float swordsmanDelay = 0.5f;
    public int maxSpawnAmount = 6;
    public int spawnedAmount = 1;

    Vector2 minPos, maxPos;
    List<GameObject> swordsmans = new List<GameObject>();

    void Start() {
        minPos = transform.GetChild(0).position;
        maxPos = transform.GetChild(1).position;
    }

    void Update() {
        for (int i = 0; i < swordsmans.Count; ++i)
            if (swordsmans[i] == null)
                swordsmans.RemoveAt(i--);
    }

    public IEnumerator SpawnWave() {
        float elapsedTime = 0f;
        int count = 0;
        Vector2 position = minPos;
        position.x = Mathf.Round(Random.Range(minPos.x, maxPos.x) * 32f) / 32f;
        CreateSwordsman(count++, position);
        while (count < spawnedAmount) {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= swordsmanDelay) {
                position.x = Mathf.Round(Random.Range(minPos.x, maxPos.x) * 32f) / 32f;
                CreateSwordsman(count++, position);
                elapsedTime = 0;
            }
            yield return null;
        }
        spawnedAmount = (int)Mathf.Ceil((float)EnemySpawner.instance.waveCount / 2f) + 1;
        if (spawnedAmount > maxSpawnAmount) spawnedAmount = maxSpawnAmount;
        yield break;
    }

    void CreateSwordsman(int i, Vector2 position) {
        var swordsman = Instantiate(swordsmanPrefab);
        swordsman.transform.position = position;
        swordsman.name += i;
        swordsmans.Add(swordsman);
    }

    public bool HasEnemies() {
        return swordsmans.Count > 0;
    }
}
