using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    private Enemy _enemy;
    
    [Header("Stats")]
    public float health = 30;
    public float baseSpeed = 5.5f;
    private float _speed;
    public float Speed {
        get { return _speed; }
        set { _speed = value; }
    }

    private int goldDropAmount;
    private int minDrop = 15;
    private int maxDrop = 30;
    
    private void Start() {
        _enemy = GetComponent<Enemy>();

        _speed = baseSpeed;
        goldDropAmount = Random.Range(minDrop, maxDrop);
    }

    public void TakeDamage(float amount) {
        health -= amount;

        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        PlayerStats.Gold += goldDropAmount;

        GameObject effect = Instantiate(_enemy.deathEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}
