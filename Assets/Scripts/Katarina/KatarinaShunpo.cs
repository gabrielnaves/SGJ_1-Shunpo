using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatarinaShunpo : MonoBehaviour {

    public float cooldownTime = 5f;
    public float cooldown;
    public LayerMask wallMasks;

    void Update() {
        cooldown += Time.deltaTime;
        if (cooldown >= cooldownTime && GameInput.GetAxisDown(InputAxes.shunpo)) {
            cooldown = 0f;
            ExecuteShunpo();
        }
    }

    void ExecuteShunpo() {
        Vector2 distance = Camera.main.ScreenToWorldPoint(GameInput.mousePosition) - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, distance, distance.magnitude);
        if (hit)
            if ((wallMasks.value & 1 << hit.transform.gameObject.layer) != 0)
                distance = distance.normalized * (hit.distance - 1);
        transform.position += (Vector3) distance;
    }
}
