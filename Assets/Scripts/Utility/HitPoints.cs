using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour {

    public int startingHitpoints = 5;
    public int hitpoints;

    void Awake() {
        hitpoints = startingHitpoints;
    }

    public void DealDamage(int amount = 1) {
        hitpoints -= amount;
    }

    public void ResetHitpoints() {
        hitpoints = startingHitpoints;
    }
}
