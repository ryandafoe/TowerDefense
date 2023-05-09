using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public Color hoverColor;
    public Color NoMoneyColor;
    public Vector3 positionOffset;

    private Renderer renderr;
    private Color startColor;

    public GameObject turret;
    public TurretPlan turretBlueprint;
    //public UpgradePanelScript upgradedTurret;
    public bool isUpgraded = false;

    BuildManager bm;

    private void Start()
    {
        //assign normal color
        renderr = GetComponent<Renderer>();
        startColor = renderr.material.color;
        bm = BuildManager.instance;
    }

    public Vector3 GetPlacePosition ()
    {
        return transform.position + positionOffset;
    }
    //when we press on the node
    private void OnMouseDown()
    {


        //if there is a turret there
        if (turret != null)
        {
            bm.SelectGroundSpace(this);
            //Debug.Log("Cant build here");
            return;
        }

        if (!bm.CanPlace)
        {
            return;
        }

        //bm.PlaceTurretOn(this);
        BuildTurret(bm.GetTurretToBuild());
    }

    //build the turret in the node script
    void BuildTurret(TurretPlan blueprint )
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetPlacePosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        Debug.Log("Turret built");

    }

    public void UpgradeTurret()
    {
        
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //call the increse fire rate

        //need to determine which tags go with with one
        if(turret!=null)
        {
            if (turret.tag == "turret")
            {
                turret.GetComponent<TurretScript>().IncreseFireRate();
            }
            if (turret.tag == "cannon")
            {
                turret.GetComponent<Turret2Script>().IncreseFireRate();
            }
            if (turret.tag == "spike")
            {
                turret.GetComponent<SpikeShooterScript>().IncreseFireRate();
            }

        }
            

        isUpgraded = true;

        Debug.Log("Turret upgraded");
    }

    public void SellTurret()
    {
        Debug.Log("Destoying");
        //destroy turret, and add money
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        if(turret != null)
            Destroy(turret);

        turretBlueprint = null;
    }


    //hover animatioon
    private void OnMouseEnter()
    {
        //change color of object
        if (!bm.CanPlace)
            return;

        if(bm.HasMoney)
        {
            renderr.material.color = hoverColor;
        }
        else
        {
            renderr.material.color = NoMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        //set back to normal color
        renderr.material.color = startColor;
    }
}
