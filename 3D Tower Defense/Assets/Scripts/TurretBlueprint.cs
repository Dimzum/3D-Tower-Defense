using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint {

    public GameObject prefab;
    public int cost;
    public int sellPrice; // sellPrice =  ~1/3 of cost

    public GameObject upgradePrefab;
    public int upgradeCost; // upgradeCost =  cost - 25g
    public int upgradeSellPrice; // upgradeSellPrice = 2 * sellPrice
}
