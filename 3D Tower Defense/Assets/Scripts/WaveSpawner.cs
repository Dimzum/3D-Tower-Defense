using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public GameMaster GM;

    public static int enemiesAlive;

    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float _countdown = 3f;

    public Text waveCountdownText;
    
    private int _waveIndex = 0;

    private void Start() {
        enemiesAlive = 0;
    }

    private void Update() {
        // Stops another wave from spawning until all enemies are killed or have reached the end
        if (enemiesAlive > 0) { return; }

        // Reset wave index
        if (_waveIndex > waves.Length) {
            GM.LevelComplete();
            this.enabled = false;
        }

        if (_countdown <= 0f) {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
            return;
        }

        // Decrease timer
        _countdown -= Time.deltaTime;
        _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);

        // Display timer
        waveCountdownText.text = "Next wave: " + string.Format("{0:00.00}", _countdown);
    }

    IEnumerator SpawnWave() {
        PlayerStats.roundsSurvived++;

        Wave wave = waves[_waveIndex];

        for (int i = 0; i < wave.enemies.Length; i++) {
            enemiesAlive += wave.enemies[i].count;
        }

        for (int i = 0; i < wave.enemies.Length; i++) {
            for (int j = 0; j < wave.enemies[i].count; j++) {
                SpawnEnemy(wave.enemies[i].enemy);
                yield return new WaitForSeconds(1f / wave.spawnRate);
            }
        }

        _waveIndex++;
    }

    void SpawnEnemy(GameObject enemy) {
        Instantiate(enemy, spawnPoint.position - Vector3.up, spawnPoint.rotation);
    }
}
