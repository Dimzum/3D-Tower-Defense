using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {

    private Enemy _enemy;
    
    [Header("Stats")]
    private float _maxHealth = 30;
    public float MaxHealth {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }
    private float health;

    public float maxSpeed = 5.5f;
    private float _speed;
    public float Speed {
        get { return _speed; }
        set { _speed = value; }
    }

    [Header("Unity Editor")]
    public Image healthBar;

    private int goldDropAmount;
    private int minDrop = 10;
    private int maxDrop = 15;
    
    private void Start() {
        _enemy = GetComponent<Enemy>();

        health = _maxHealth;
        _speed = maxSpeed;
        goldDropAmount = Random.Range(minDrop, maxDrop);
    }

    public void TakeDamage(float amount) {
        health -= amount;
        // Enemy health UI
        healthBar.fillAmount = health / _maxHealth;

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
