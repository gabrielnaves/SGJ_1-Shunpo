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

        Vector2 velocity = new Vector2(1f, Random.Range(0, 1f * Mathf.Sign((shootingPoint.position - transform.position).x))).normalized;
        arrow.GetComponent<Rigidbody2D>().velocity = velocity * arrowVelocity * Mathf.Sign((shootingPoint.position - transform.position).x);
    }

    void Start() {
        hitPoints = GetComponent<HitPoints>();
        if (EnemySpawner.instance.waveCount > 8) hitPoints.hitpoints *= 2;
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
            if (Katarina.instance) {
                Katarina.instance.GetComponent<KatarinaShunpo>().cooldown += Katarina.instance.killCDReduction;
                Katarina.instance.GetComponentInChildren<KatarinaDeathLotus>().cooldown += Katarina.instance.killCDReduction;
            }
        }
    }
}
