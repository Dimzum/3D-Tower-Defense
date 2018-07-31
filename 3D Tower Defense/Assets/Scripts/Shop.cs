using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    public TurretBlueprint basicTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint sniperTurret;
    public TurretBlueprint laserBeamer;

    private void Start() {
        buildManager = BuildManager.instance;
    }

    public void SelectBasicTurret() {
        Debug.Log("Basic Turret Selected.");
        buildManager.SelectTurretToBuild(basicTurret);
    }

    public void SelectMissileLauncher() {
        Debug.Log("Missile Launcher Selected.");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectSniperTurret() {
        Debug.Log("Sniper Turret Selected.");
        buildManager.SelectTurretToBuild(sniperTurret);
    }

    public void SelectLaserBeamer() {
        Debug.Log("Laser Beamer Selected.");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
