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

    private TurretBlueprint _turretToBuild;
    public TurretBlueprint TurretToBuild {
        get { return _turretToBuild; }
        set { _turretToBuild = value; }
    }

    public GameObject buildEffect;

    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasEnoughGold { get { return PlayerStats.Gold >= _turretToBuild.cost; } }

    public void BuildTurretOn(Node node) {
        if (PlayerStats.Gold < _turretToBuild.cost) {
            Debug.Log("Not enough gold to build that!");
            return;
        }

        PlayerStats.Gold -= _turretToBuild.cost;

        GameObject turret = Instantiate(_turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity) as GameObject;
        node.Turret = turret;

        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity) as GameObject;
        Destroy(effect, 5f);
    }

    public void SelectTurretToBuild(TurretBlueprint turret) {
        _turretToBuild = turret;
    }
}
