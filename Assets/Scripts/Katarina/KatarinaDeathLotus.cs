using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatarinaDeathLotus : MonoBehaviour {

    public float cooldownTime = 60f;
    public float cooldown;
    public float daggerTime = 0.4f;
    public float lotusDuration = 3f;
    public float angleIncrement = 1f;
    public float daggerVelocity;
    public GameObject flurry;
    public GameObject daggerPrefab;

    bool active;

    void Start() {
        angleIncrement *= Mathf.Deg2Rad;
    }

    void Update() {
        if (!active) {
            cooldown += Time.deltaTime;
            if (cooldown >= cooldownTime && GameInput.GetAxisDown(InputAxis.DeathLotus)) {
                cooldown = 0f;
                StartCoroutine(DeathLotus());
            }
        }
    }

    IEnumerator DeathLotus() {
        DisableOtherKatarinaStates();
        active = true;
        float elapsedTime = 0;
        float daggerTimer = 0;
        float angle = 0;
        while (elapsedTime < lotusDuration) {
            if (daggerTimer > daggerTime) {
                ThrowDagger(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)));
                angle += angleIncrement;
                daggerTimer = 0;
            }
            elapsedTime += Time.deltaTime;
            daggerTimer += Time.deltaTime;
            yield return null;
        }
        EnableOtherKatarinaStates();
        active = false;
    }

    void ThrowDagger(Vector2 launchVector) {
        var dagger = Instantiate(daggerPrefab);
        dagger.transform.position = transform.position + (Vector3)(launchVector.normalized);
        dagger.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(launchVector.y, launchVector.x) * Mathf.Rad2Deg - 90);
        dagger.GetComponent<Rigidbody2D>().velocity = launchVector.normalized * daggerVelocity;
        dagger.GetComponent<Damage>().damageDealt = 3;
    }

    public void DisableOtherKatarinaStates() {
        var katarina = Katarina.instance;
        katarina.GetComponent<KatarinaMovement>().enabled = false;
        katarina.GetComponent<KatarinaJump>().enabled = false;
        katarina.GetComponent<KatarinaShunpo>().enabled = false;
        katarina.GetComponentInChildren<KatarinaFlurry>().enabled = false;

        katarina.GetComponent<SpriteRenderer>().enabled = false;
        katarina.GetComponent<BoxCollider2D>().enabled = false;
        katarina.GetComponent<Rigidbody2D>().gravityScale = 0;
        katarina.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        katarina.GetComponent<HitPoints>().invincible = true;
        flurry.SetActive(true);
    }

    public void EnableOtherKatarinaStates() {
        var katarina = Katarina.instance;
        katarina.GetComponent<KatarinaMovement>().enabled = true;
        katarina.GetComponent<KatarinaJump>().enabled = true;
        katarina.GetComponent<KatarinaShunpo>().enabled = true;
        katarina.GetComponentInChildren<KatarinaFlurry>().enabled = true;

        katarina.GetComponent<SpriteRenderer>().enabled =true;
        katarina.GetComponent<BoxCollider2D>().enabled = true;
        katarina.GetComponent<Rigidbody2D>().gravityScale = Katarina.instance.gravityScale;
        katarina.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        katarina.GetComponent<HitPoints>().invincible = false;
        flurry.SetActive(false);
    }
}
