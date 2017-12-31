using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour {

    public Transform shootingPoint;
    public GameObject arrowPrefab;
    public float shootingTime = 1.5f;
    public float arrowVelocity = 20f;

    bool shooting;
    float elapsedTime;
    HitPoints hitPoints;

    public void ShootArrow() {
        shooting = false;
        elapsedTime = 0;
        var arrow = Instantiate(arrowPrefab);
        arrow.transform.position = shootingPoint.position;
        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowVelocity * Mathf.Sign((shootingPoint.position - transform.position).x), 0);
    }

    void Start() {
        hitPoints = GetComponent<HitPoints>();
        shootingTime *= (1 - (float)(EnemySpawner.instance.waveCount-1) / EnemySpawner.instance.startingWaveTime);
    }

    void Update() {
        elapsedTime += Time.deltaTime;
        if (!shooting && elapsedTime > shootingTime) {
            shooting = true;
            GetComponent<Animator>().SetTrigger("shoot");
        }
        if (hitPoints.Died()) {
            KillCount.instance.IncreaseCount();
            GetComponent<Collider2D>().enabled = false;
            enabled = false;
            Katarina.instance.GetComponent<KatarinaShunpo>().cooldown += Katarina.instance.killCDReduction;
        }
    }
}
