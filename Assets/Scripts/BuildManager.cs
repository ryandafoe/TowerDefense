using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretPlan turretToPlace;
    public GameObject turret;
    public GameObject cannon;
    public GameObject turret3;

    private GroundScript selectedSpace;
    public UpgradePanelScript UPS;
    //singleton pattern to reference ONE instance of build manager
    public static BuildManager instance;

    private void Awake()
    {
        instance = this;
    }



    private void Start()
    {

    }

    public bool CanPlace { get {return turretToPlace != null;} }
    public bool HasMoney { get {return PlayerStats.Money >= turretToPlace.cost;} }


    public void SetTurretToPlace(TurretPlan turret)
    {
        turretToPlace = turret;
        selectedSpace = null;

        UPS.HideMenu();
    }

    public void SelectGroundSpace(GroundScript gs)
    {
        if(selectedSpace == gs)
        {
            DeselectSpace();
            return;
        }
        selectedSpace = gs;
        turretToPlace = null;

        UPS.OpenMenu();
    }
    public void DeselectSpace()
    {
        selectedSpace = null;
        UPS.HideMenu();
    }

    public TurretPlan GetTurretToBuild()
    {
        return turretToPlace;
    }

    public void Sell()
    {
        selectedSpace.SellTurret();
        BuildManager.instance.DeselectSpace();
    }

    public void Upgrade()
    {
        selectedSpace.UpgradeTurret();
        BuildManager.instance.DeselectSpace();
    }

}
