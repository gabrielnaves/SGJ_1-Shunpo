using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatarinaShunpo : MonoBehaviour {

    public float cooldownTime = 5f;
    public float cooldown;
    public LayerMask wallMasks;
    public GameObject shunpoDamageHitbox;

    Vector2 distance;

    void Update() {
        cooldown += Time.deltaTime;
        if (cooldown >= cooldownTime && GameInput.GetAxisDown(InputAxes.shunpo)) {
            cooldown = 0f;
            ExecuteShunpo();
        }
    }

    void ExecuteShunpo() {
        distance = Camera.main.ScreenToWorldPoint(GameInput.mousePosition) - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, distance, distance.magnitude);
        if (hit)
            if ((wallMasks.value & 1 << hit.transform.gameObject.layer) != 0)
                distance = distance.normalized * (hit.distance - 1);
        distance.y -= GetComponent<SpriteRenderer>().bounds.extents.y;
        GetComponent<Animator>().SetTrigger("shunpo");
        DisableOtherKatarinaStates();
    }

    void TeleportKatarina() {
        transform.position += (Vector3) distance;
    }

    public void EnableShunpoDamage() {
        shunpoDamageHitbox.SetActive(true);
    }

    public void DisableShunpoDamage() {
        shunpoDamageHitbox.SetActive(false);
    }

    // Gambiarras a mil
    public void DisableOtherKatarinaStates() {
        var katarina = Katarina.instance;
        katarina.GetComponent<BoxCollider2D>().enabled = false;
        katarina.GetComponent<KatarinaMovement>().enabled = false;
        katarina.GetComponent<KatarinaJump>().enabled = false;
        katarina.GetComponentInChildren<KatarinaFlurry>().enabled = false;
        katarina.GetComponent<Rigidbody2D>().gravityScale = 0;
        katarina.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void EnableOtherKatarinaStates() {
        var katarina = Katarina.instance;
        katarina.GetComponent<BoxCollider2D>().enabled = true;
        katarina.GetComponent<KatarinaMovement>().enabled = true;
        katarina.GetComponent<KatarinaJump>().enabled = true;
        katarina.GetComponentInChildren<KatarinaFlurry>().enabled = true;
        katarina.GetComponent<Rigidbody2D>().gravityScale = Katarina.instance.gravityScale;
        katarina.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
