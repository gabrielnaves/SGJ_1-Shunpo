using System.Collections;
using UnityEngine;

public class KatarinaFlurry : MonoBehaviour {

    public float flurryTime = 0.5f;
    public GameObject flurry;
    public GameObject katarina;
    public LayerMask flurryEnabler;
    public bool active;

    void OnTriggerStay2D(Collider2D other) {
        if (enabled) {
            if ((flurryEnabler.value & 1 << other.gameObject.layer) != 0) {
                if (other.transform.parent.parent.GetComponent<Dagger>().timeSinceInstantiation > 0.1f) {
                    if (!active)
                        ActivateFlurry();
                    Destroy(other.transform.parent.parent.gameObject);
                    DaggerCount.instance.CollectedDagger();
                }
            }
        }
    }

    void ActivateFlurry() {
        active = true;
        katarina.GetComponent<SpriteRenderer>().enabled = false;
        katarina.GetComponent<BoxCollider2D>().enabled = false;
        katarina.GetComponent<KatarinaMovement>().enabled = false;
        katarina.GetComponent<KatarinaJump>().enabled = false;
        katarina.GetComponent<KatarinaShunpo>().enabled = false;
        katarina.GetComponent<Rigidbody2D>().gravityScale = 0;
        katarina.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        katarina.GetComponent<HitPoints>().invincible = true;
        flurry.SetActive(true);
        StartCoroutine(WaitForFlurry());
    }

    IEnumerator WaitForFlurry() {
        yield return new WaitForSeconds(flurryTime);
        DeactivateFlurry();
    }

    void DeactivateFlurry() {
        active = false;
        katarina.GetComponent<SpriteRenderer>().enabled = true;
        katarina.GetComponent<BoxCollider2D>().enabled = true;
        katarina.GetComponent<KatarinaMovement>().enabled = true;
        katarina.GetComponent<KatarinaShunpo>().enabled = true;
        katarina.GetComponent<KatarinaJump>().enabled = true;
        katarina.GetComponent<KatarinaJump>().Jump();
        katarina.GetComponent<Rigidbody2D>().gravityScale = Katarina.instance.gravityScale;
        katarina.GetComponent<HitPoints>().invincible = false;
        flurry.SetActive(false);
    }
}
