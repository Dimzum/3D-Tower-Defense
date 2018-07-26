using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private EnemyStats _enemyStats;
    public EnemyStats EnemyStats {
        get { return _enemyStats; }
    }

    private EnemyController _enemyController;
    public EnemyController EnemyController {
        get { return _enemyController; }
    }

    public GameObject deathEffect;

    private void Start() {
        _enemyStats = GetComponent<EnemyStats>();
        _enemyController = GetComponent<EnemyController>();
    }
}
