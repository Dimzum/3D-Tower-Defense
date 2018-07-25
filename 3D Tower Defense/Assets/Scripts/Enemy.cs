using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health = 30;
    public float speed = 5.5f;

    private int goldDropAmount;
    private int minDrop = 15;
    private int maxDrop = 30;

    private Transform target;
    private int waypointIndex = 0;

    public GameObject deathEffect;

    private void Start() {
        target = Waypoints.waypoints[0];

        goldDropAmount = Random.Range(minDrop, maxDrop);
    }

    private void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.3f) {
            GetNextWaypoint();
        }
    }

    public void TakeDamage(int amount) {
        health -= amount;

        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        PlayerStats.Gold += goldDropAmount;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(effect, 2f);
        Destroy(gameObject);
    }

    void GetNextWaypoint() {
        if (waypointIndex >= Waypoints.waypoints.Length - 1) {
            DestinationReached();
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    void DestinationReached() {
        PlayerStats.Health--;
        Destroy(gameObject);
    }
}
