using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 15.5f;
    private float _countdown = 2.5f;
    private float spawnDelay = 0.75f;

    public Text waveCountdownText;
    
    private int _waveIndex = 0;

    private void Update() {
        if (_countdown <= 0f) {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Floor(_countdown).ToString();
    }

    IEnumerator SpawnWave() {
        _waveIndex++;

        //for (int i = 0; i < Mathf.Pow(_waveIndex, (_waveIndex - 1)); i++) {
        for (int i = 0; i < _waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
