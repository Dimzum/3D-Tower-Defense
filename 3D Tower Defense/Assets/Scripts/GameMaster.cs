using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static bool isGameOver = false;
	
	// Update is called once per frame
	void Update () {
        if (isGameOver) { return; }

		if (PlayerStats.Health <= 0) {
            EndGame();
        }
	}

    void EndGame() {
        isGameOver = true;
        Debug.Log("GAME OVER!");
    }
}
