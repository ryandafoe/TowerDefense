using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelScript : MonoBehaviour
{

    public GameObject ui;
    private GroundScript target;
    //public int upgradeCost;
    //public GameObject upgradedPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(GroundScript selectedTarget)
    {
        target = selectedTarget;

        transform.position = target.GetPlacePosition();

        ui.SetActive(true);
    }

    public void OpenMenu()
    {
        ui.SetActive(true);
    }

    public void HideMenu()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectSpace();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectSpace();
    }

}
