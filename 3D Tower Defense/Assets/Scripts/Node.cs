using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    BuildManager buildManager;
    
    private Renderer rend;

    private Color defaultColor;
    public Color hoverColor;

    private GameObject turret;
    public Vector3 positionOffset;

    private void Start() {
        buildManager = BuildManager.instance;

        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
    }

    private void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        // Check to see if turret to build is null
        if (buildManager.TurretToBuild == null) { return; }

        if (turret != null) {
            Debug.Log("Can't build here.");
            return;
        }

        GameObject turretToBuild = buildManager.TurretToBuild;
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation) as GameObject;
    }

    private void OnMouseEnter() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        // Check to see if turret to build is null
        if (buildManager.TurretToBuild == null) { return; }

        rend.material.color = hoverColor;
    }

    private void OnMouseExit() {
        rend.material.color = defaultColor;
    }
}
