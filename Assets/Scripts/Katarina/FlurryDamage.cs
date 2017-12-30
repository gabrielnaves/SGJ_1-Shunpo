using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlurryDamage : MonoBehaviour {

    public LayerMask damagingLayers;
    List<GameObject> hitObjects = new List<GameObject>();

    void OnDisable() {
        hitObjects.Clear();
    }

    void OnTriggerStay2D(Collider2D other) {
        if ((damagingLayers.value & 1 << other.gameObject.layer) != 0) {
            if (!hitObjects.Contains(other.gameObject)) {
                var hitpoints = other.gameObject.GetComponent<HitPoints>();
                if (hitpoints)
                    hitpoints.DealDamage();
                hitObjects.Add(other.gameObject);
            }
        }
    }
}
