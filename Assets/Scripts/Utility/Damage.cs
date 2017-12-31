using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public LayerMask damagingLayers;
    public int damageDealt = 1;

    void OnCollisionEnter2D(Collision2D other) {
        if ((damagingLayers.value & 1 << other.gameObject.layer) != 0 && enabled) {
            var hitpoints = other.gameObject.GetComponent<HitPoints>();
            if (hitpoints)
                hitpoints.DealDamage(damageDealt);
        }
    }
}
