using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    private void Start() {
        buildManager = BuildManager.instance;
    }

    public void PurchaseBasicTurret() {
        Debug.Log("Basic Turret Selected.");
        buildManager.SetTurretToBuild(buildManager.basicTurretPrefab);
    }

    public void PurchaseMissileLauncher() {
        Debug.Log("Misile Launcher Selected.");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
