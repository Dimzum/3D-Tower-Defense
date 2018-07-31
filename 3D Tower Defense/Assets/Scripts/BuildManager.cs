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

    private Node _selectedNode;
    public Node SelectedNode {
        get { return _selectedNode; }
        set { _selectedNode = value; }
    }

    private TurretBlueprint _turretToBuild;
    public TurretBlueprint TurretToBuild {
        get { return _turretToBuild; }
        set { _turretToBuild = value; }
    }

    public GameObject buildEffect;
    public GameObject sellEffect;

    public TurretUI turretUI;

    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasEnoughGold { get { return PlayerStats.Gold >= _turretToBuild.cost; } }
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Hide turretUI
            DeselectNode();
        }
    }

    public void SelectNode(Node node) {
        if (_selectedNode == node) {
            DeselectNode();
            return;
        }

        _selectedNode = node;
        _turretToBuild = null;

        turretUI.SetTarget(node);
    }

    public void DeselectNode() {
        _selectedNode = null;
        turretUI.HideUI();
    }

    public void SelectTurretToBuild(TurretBlueprint turret) {
        _turretToBuild = turret;
        _selectedNode = null;

        turretUI.HideUI();
    }
}
