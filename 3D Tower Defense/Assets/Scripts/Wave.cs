using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave {

    [System.Serializable]
    public class EnemyDict {
        public GameObject enemy;
        public int count;
    }

    //public string waveName;
    public EnemyDict[] enemies;
    //public GameObject enemy;
    //public int numEnemies;
    public float spawnRate;
}
