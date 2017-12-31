using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSpawner : MonoBehaviour {

    public GameObject archerPrefab;

    List<Transform> spawnLocations = new List<Transform>();
    List<GameObject> archers = new List<GameObject>();

    void Start() {
        foreach (Transform child in transform)
            spawnLocations.Add(child);
    }

    void Update() {
        for (int i = 0; i < archers.Count; ++i)
            if (archers[i] == null)
                archers.RemoveAt(i--);
    }

    public void SpawnWave() {
        for (int i = 0; i < spawnLocations.Count; ++i) {
            var archer = Instantiate(archerPrefab);
            archer.transform.position = spawnLocations[i].position;
            archer.transform.rotation = spawnLocations[i].rotation;
            archer.name += i;
            archers.Add(archer);
        }
    }

    public bool NoEnemies() {
        return archers.Count == 0;
    }
}
