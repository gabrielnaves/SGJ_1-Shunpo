using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSpawner : MonoBehaviour {

    public GameObject archerPrefab;
    public float archerDelay = 0.5f;

    List<Transform> spawnLocations = new List<Transform>();
    List<GameObject> archers = new List<GameObject>();
    int leftovers;

    void Start() {
        foreach (Transform child in transform)
            spawnLocations.Add(child);
        leftovers = spawnLocations.Count - 1;
    }

    void Update() {
        for (int i = 0; i < archers.Count; ++i)
            if (archers[i] == null)
                archers.RemoveAt(i--);
    }

    public IEnumerator SpawnWave() {
        List<Transform> shuffleLocations = new List<Transform>(spawnLocations);
        float elapsedTime = 0f;
        int count = 0;
        int selected = Random.Range(0, shuffleLocations.Count);
        CreateArcher(count++, shuffleLocations[selected]);
        shuffleLocations.RemoveAt(selected);
        while (shuffleLocations.Count > leftovers) {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= archerDelay) {
                selected = Random.Range(0, shuffleLocations.Count);
                CreateArcher(count++, shuffleLocations[selected]);
                shuffleLocations.RemoveAt(selected);
                elapsedTime = 0;
            }
            yield return null;
        }
        if (leftovers > 0) leftovers--;
    }

    void CreateArcher(int i, Transform location) {
        var archer = Instantiate(archerPrefab);
        archer.transform.position = location.position;
        archer.transform.rotation = location.rotation;
        archer.name += i;
        archers.Add(archer);
    }

    public bool NoEnemies() {
        return archers.Count == 0;
    }
}
