using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private int startingHealth = 20;
    public static int Health;

    public int startingGold = 125;
    public static int Gold;

    public static int roundsSurvived;

    private void Start() {
        Health = startingHealth;
        Gold = startingGold;

        roundsSurvived = 0;
    }
}
