using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    BuildManager buildManager;
    
    private Renderer rend;

    private Color defaultColor;
    public Color hoverColor;
    public Color notEnoughGoldColor;

    //public Vector3 positionOffset;
    
    private GameObject _turret;
    public GameObject Turret {
        get { return _turret; }
        set { _turret = value; }
    }

    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;

    private void Start() {
        buildManager = BuildManager.instance;

        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
    }

    public Vector3 GetBuildPosition() {
        return transform.position;
    }

    private void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (_turret != null) {
            buildManager.SelectNode(this);
            return;
        }

        // Check to see if turret to build is null
        if (!buildManager.CanBuild) { return; }

        BuildTurret(buildManager.TurretToBuild);
    }

    // Build a Turret
    void BuildTurret(TurretBlueprint blueprint) {
        if (PlayerStats.Gold < blueprint.cost) {
            Debug.Log("Not enough gold to build that!");
            return;
        }

        PlayerStats.Gold -= blueprint.cost;

        Vector3 offSet = new Vector3(0, blueprint.prefab.transform.position.y, 0);
        GameObject turret = Instantiate(blueprint.prefab, GetBuildPosition() + offSet, Quaternion.identity) as GameObject;
        _turret = turret;

        turretBlueprint = blueprint;

        // Spawns effect when turret is built
        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity) as GameObject;
        Destroy(effect, 3f);
    }

    // Upgrade a turret
    public void UpgradeTurret() {
        if (PlayerStats.Gold < turretBlueprint.upgradeCost) {
            Debug.Log("Not enough gold to upgrade that!");
            return;
        }

        PlayerStats.Gold -= turretBlueprint.upgradeCost;

        // Destroy current turret object
        Destroy(_turret);

        // Building an upgraded turret
        Vector3 offSet = new Vector3(0, turretBlueprint.upgradePrefab.transform.position.y, 0);
        GameObject turret = Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition() + offSet, Quaternion.identity) as GameObject;
        _turret = turret;

        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity) as GameObject;
        Destroy(effect, 3f);

        isUpgraded = true;
    }

    // Sell a Turret
    public void SellTurret() {
        // Check if turret is upgraded, sell for upgraded price
        if (isUpgraded) {
            PlayerStats.Gold += turretBlueprint.upgradeSellPrice;
        } else {
            PlayerStats.Gold += turretBlueprint.sellPrice;
        }

        //Spawn effect when turret is sold
        GameObject effect = Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity) as GameObject;
        Destroy(effect, 3f);

        Destroy(_turret);
        turretBlueprint = null;
        isUpgraded = false;
    }

    // Hover over node animation
    private void OnMouseEnter() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        // Check to see if turret to build is null
        if (!buildManager.CanBuild) { return; }

        if (buildManager.HasEnoughGold) {
            rend.material.color = hoverColor;
        } else {
            rend.material.color = notEnoughGoldColor;
        }
    }

    // Returns color to normal is mouse is no longer hovering over node
    private void OnMouseExit() {
        rend.material.color = defaultColor;
    }
}
