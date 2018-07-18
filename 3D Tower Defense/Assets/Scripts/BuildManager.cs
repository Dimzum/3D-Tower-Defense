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

    private void Start() {
        _turretToBuild = basicTurretPrefab;
    }

    private GameObject _turretToBuild;
    public GameObject TurretToBuild {
        get { return _turretToBuild; }
    }
}
