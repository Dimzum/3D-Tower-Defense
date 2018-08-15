using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-------------------- CHEAT CODES --------------------*/
public class CheatCodeMaster : MonoBehaviour {

    public GameMaster GM;

    private int goldAmount = 9999;
	
	// Update is called once per frame
	void Update () {
        // End the game
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            GM.EndGame();
        }

        // Autocomplete Level
        if (Input.GetKeyDown(KeyCode.Alpha9)) {
            GM.LevelComplete();
        }

        // Set gold to 9999
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            PlayerStats.Gold = goldAmount;
        }
    }
}
