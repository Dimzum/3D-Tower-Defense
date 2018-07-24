using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private int startingHealth = 20;
    public static int Health;

    private int startingGold = 75;
    public static int Gold;

    private void Start() {
        Health = startingHealth;
        Gold = startingGold;
    }
}
