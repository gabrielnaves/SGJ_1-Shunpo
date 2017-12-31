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
        if (hitpoints <= 0)
            Die();
    }

    public void ResetHitpoints() {
        hitpoints = startingHitpoints;
    }

    public bool Died() {
        return hitpoints <= 0;
    }

    void Die() {
        var animator = GetComponent<Animator>();
        if (animator)
            animator.SetTrigger("died");
    }
}
