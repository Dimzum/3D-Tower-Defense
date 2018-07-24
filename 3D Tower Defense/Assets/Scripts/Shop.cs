using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    public TurretBlueprint basicTurret;
    public TurretBlueprint missileLauncher;

    private void Start() {
        buildManager = BuildManager.instance;
    }

    public void SelectBasicTurret() {
        Debug.Log("Basic Turret Selected.");
        buildManager.SelectTurretToBuild(basicTurret);
    }

    public void SelectMissileLauncher() {
        Debug.Log("Misile Launcher Selected.");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
