using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    #region Singleton
    public static BuildManager instance;

    private void Awake() {
        if (instance != null) {
            Debug.LogError("Mopre than one BuildManager in scene.");
            return;
        }

        instance = this;
    }
    #endregion

    public GameObject basicTurretPrefab;
    public GameObject missileLauncherPrefab;

    private GameObject _turretToBuild;
    public GameObject TurretToBuild {
        get { return _turretToBuild; }
        set { _turretToBuild = value; }
    }

    public void SetTurretToBuild(GameObject turret) {
        TurretToBuild = turret;
    }
}
