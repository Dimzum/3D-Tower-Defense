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

    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject _turret;
    public GameObject Turret {
        get { return _turret; }
        set { _turret = value; }
    }

    private void Start() {
        buildManager = BuildManager.instance;

        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
    }

    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
    }

    private void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        // Check to see if turret to build is null
        if (!buildManager.CanBuild) { return; }

        if (_turret != null) {
            Debug.Log("Can't build here.");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

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

    private void OnMouseExit() {
        rend.material.color = defaultColor;
    }
}
