using UnityEngine;

public class Enemy : MonoBehaviour {
    
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float maxHealth = 100.0f;

    public void Hit(float damage) {

        if(health - damage <= 0.0f) {

            health = 0.0f;
            Destroy(gameObject);
            return;

        }
        health -= damage;

    }

}