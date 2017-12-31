using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour {

    public int startingHitpoints = 5;
    public int hitpoints;
    public bool invincible;

    void Awake() {
        hitpoints = startingHitpoints;
        var hpBar = GetComponentInChildren<HealthBar>();
        if (hpBar)
            hpBar.SetHitPoints(this);
    }

    public void DealDamage(int amount = 1) {
        if (!invincible) {
            hitpoints -= amount;
            if (hitpoints <= 0)
                Die();
        }
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
