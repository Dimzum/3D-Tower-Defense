using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {

    private Enemy _enemy;
    
    [Header("Stats")]
    public float _maxHealth = 30;
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

    private int goldDropAmount;
    public int minGoldDrop = 10;
    public int maxGoldDrop = 15;

    [Header("Unity Editor")]
    public Image healthBar;

    private bool isDead = false;
    
    private void Start() {
        _enemy = GetComponent<Enemy>();

        health = _maxHealth;
        _speed = maxSpeed;
        goldDropAmount = Random.Range(minGoldDrop, maxGoldDrop);
    }

    public void TakeDamage(float amount) {
        health -= amount;
        // Enemy health UI
        healthBar.fillAmount = health / _maxHealth;

        if (health <= 0 && !isDead) {
            Die();
        }
    }

    void Die() {
        isDead = true;

        PlayerStats.Gold += goldDropAmount;

        GameObject effect = Instantiate(_enemy.deathEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(effect, 2f);

        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
