using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatarinaFlurry : MonoBehaviour {

    public float flurryTime = 0.5f;
    public GameObject flurry;
    public GameObject katarina;
    public LayerMask flurryEnabler;
    public bool active;

    float elapsedTime;
    float gravityScale;

    void OnTriggerEnter2D(Collider2D other) {
        if ((flurryEnabler.value & 1 << other.gameObject.layer) != 0 && !active) {
            if (other.transform.parent.GetComponent<Dagger>().timeSinceInstantiation > 0.1f) {
                ActivateFlurry();
                Destroy(other.transform.parent.gameObject);
            }
        }
    }

    void Update() {
        if (active) {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= flurryTime)
                DeactivateFlurry();
        }
    }

    void ActivateFlurry() {
        active = true;
        elapsedTime = 0;
        katarina.GetComponent<SpriteRenderer>().enabled = false;
        katarina.GetComponent<BoxCollider2D>().enabled = false;
        katarina.GetComponent<KatarinaMovement>().enabled = false;
        katarina.GetComponent<KatarinaJump>().enabled = false;
        gravityScale = katarina.GetComponent<Rigidbody2D>().gravityScale;
        katarina.GetComponent<Rigidbody2D>().gravityScale = 0;
        katarina.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        flurry.SetActive(true);
    }

    void DeactivateFlurry() {
        active = false;
        katarina.GetComponent<SpriteRenderer>().enabled = true;
        katarina.GetComponent<BoxCollider2D>().enabled = true;
        katarina.GetComponent<KatarinaMovement>().enabled = true;
        katarina.GetComponent<KatarinaJump>().enabled = true;
        katarina.GetComponent<KatarinaJump>().Jump();
        katarina.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        flurry.SetActive(false);
    }
}
