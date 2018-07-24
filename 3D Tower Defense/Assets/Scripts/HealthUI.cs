using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public Text healthText;

    // Update is called once per frame
    void Update() {
        healthText.text = "Health: " + PlayerStats.Health.ToString();
    }
}
