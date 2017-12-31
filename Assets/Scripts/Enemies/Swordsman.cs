using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman : MonoBehaviour {

    public GameObject damageBox;
    public float attackTime = 3f;
    public float attackDuration = 1f;
    public float velocity = 2f;

    float elapsedTime;
    bool attacking;

    Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        elapsedTime += Time.deltaTime;
        if (attacking && elapsedTime >= attackDuration)
            EndAttack();
        else if (!attacking && elapsedTime >= attackTime)
            StartAttack();
        if (GetComponent<HitPoints>().Died()) {
            Katarina.instance.GetComponent<KatarinaShunpo>().cooldown += Katarina.instance.killCDReduction;
            KillCount.instance.IncreaseCount();
            GetComponent<Collider2D>().enabled = false;
            enabled = false;
        }
    }

    void FixedUpdate() {
        if (attacking)
            MoveTowardsPlayer();
    }

    void StartAttack() {
        attacking = true;
        animator.SetTrigger("attack");
        elapsedTime = 0;
        damageBox.SetActive(true);
        GetComponent<HitPoints>().invincible = true;
    }

    void EndAttack() {
        attacking = false;
        animator.SetTrigger("endAttack");
        elapsedTime = 0;
        damageBox.SetActive(false);
        GetComponent<HitPoints>().invincible = false;
    }

    void MoveTowardsPlayer() {
        var distance = Katarina.instance.transform.position.x - transform.position.x;
        var position = transform.position;
        position.x += (velocity * Time.deltaTime * Mathf.Sign(distance));
        transform.position = position;
    }
}
