using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    
    private Renderer rend;

    private Color defaultColor;
    public Color hoverColor;

    private GameObject turret;
    public Vector3 positionOffset;

    private void Start() {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
    }

    private void OnMouseDown() {
        if (turret != null) {
            Debug.Log("Can't build here.");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.TurretToBuild;
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation) as GameObject;
    }

    private void OnMouseEnter() {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit() {
        rend.material.color = defaultColor;
    }
}
