using System;
using UnityEngine;

public class Character : MonoBehaviour {
    
    public static Character instance;

    private void Awake() {
        
        instance = this;

    }

    [Header("Health")]
    [SerializeField] private int lives = 3;
    [SerializeField] private int maxLives = 3;
    [SerializeField] private bool alive = true;

    [Header("Knock out")]
    [SerializeField] private bool knockedOut = false;
    [SerializeField] private float knockOutDuration = 1.5f;
    private DateTime previousKnockOut;

    [Header("Script Instances")]
    [SerializeField] private Movement movement;

    [Header("Attacking")]
    [SerializeField] private float damage = 20.0f;
    [SerializeField] private Enemy enemyInFront;

    private void Update() {
        
        if(knockedOut && DateTime.Now >= previousKnockOut.AddSeconds(knockOutDuration)) {

            knockedOut = false;
            movement.canMove = true;

        }

        if(enemyInFront && Input.GetKeyDown(KeyCode.X))
            enemyInFront.Hit(damage);

    }

    public void Hit() {

        if(!alive) return;

        lives--;
        if(lives == 0) Die();

    }
    public void KnockOut() {

        if (!alive) return;

        movement.canMove = false;
        knockedOut = true;
        previousKnockOut = DateTime.Now;

    }

    public int GetLives() { return lives; }

    private void Die() {

        alive = false;
        movement.canMove = false;

    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.tag != "Enemy") return;
        enemyInFront = other.GetComponent<Enemy>();

    }
    private void OnTriggerExit(Collider other) {
        
        if (other.tag != "Enemy") return;
        enemyInFront = null;

    }

}