using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 15f;
    private float _countdown = 3f;
    private float spawnDelay = 0.55f;

    public Text waveCountdownText;
    
    private int _waveIndex = 0;

    private void Update() {
        if (_countdown <= 0f) {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;
        _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = "Next wave: " + string.Format("{0:00.00}", _countdown);
    }

    IEnumerator SpawnWave() {
        _waveIndex++;
        PlayerStats.rounds++;

        //for (int i = 0; i < Mathf.Pow(_waveIndex, (_waveIndex - 1)); i++) {
        for (int i = 0; i < _waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position - new Vector3(0, 1.2f, 0), spawnPoint.rotation);
    }
}
