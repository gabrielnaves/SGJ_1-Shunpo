using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatarinaThrowDagger : MonoBehaviour {

    public GameObject daggerPrefab;
    public float cooldownTime = 1f;
    public float cooldown = 0;
    public float daggerVelocity = 20f;

    void Update() {
        cooldown += Time.deltaTime;
        if (cooldown > cooldownTime && GameInput.GetAxisDown(InputAxes.daggerThrow)) {
            cooldown = 0;
            Vector2 launchVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            var dagger = Instantiate(daggerPrefab);
            dagger.transform.position = transform.position + (Vector3)(launchVector.normalized * 0.27f);
            dagger.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(launchVector.y, launchVector.x) * Mathf.Rad2Deg - 90);
            dagger.GetComponent<Rigidbody2D>().velocity = launchVector.normalized * daggerVelocity;
        }
    }
}
