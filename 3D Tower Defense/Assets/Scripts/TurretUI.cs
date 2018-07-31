using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour {

    public GameObject turretUI;

    private Node _target;

    public Button upgradeButton;
    public Text upgradeCostText;
    public Text sellPriceText;

    public void SetTarget(Node target) {
        _target = target;

        transform.position = target.GetBuildPosition();

        // If turret is not upgraded
        if (!_target.isUpgraded) {
            upgradeCostText.text = _target.turretBlueprint.upgradeCost + "g";
            upgradeButton.interactable = true;
            sellPriceText.text = _target.turretBlueprint.sellPrice + "g";
        } else { // If target is upgraded
            upgradeCostText.text = "MAX";
            upgradeButton.interactable = false;
            sellPriceText.text = _target.turretBlueprint.upgradeSellPrice + "g";
        }

        turretUI.SetActive(true);
    }

    public void HideUI() {
        turretUI.SetActive(false);
    }

    public void Upgrade() {
        _target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell() {
        _target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
