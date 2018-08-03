using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyController : MonoBehaviour {

    private EnemyStats _enemyStats;

    [Header("Waypoint")]
    private Transform target; // Waypoint
    private int waypointIndex = 0;

    // Use this for initialization
    private void Start() {
        _enemyStats = GetComponent<EnemyStats>();

        target = Waypoints.waypoints[0];
    }

    private void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * _enemyStats.Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.3f) {
            GetNextWaypoint();
        }

        _enemyStats.Speed = _enemyStats.maxSpeed;
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
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }

    public void Slow(float percent) {
        _enemyStats.Speed = _enemyStats.maxSpeed * (1f - percent);
    }
}
