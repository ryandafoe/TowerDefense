using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public TurretPlan regularTurret;
    public TurretPlan cannonTurret;
    public TurretPlan turret3;

    BuildManager bm;

    // Start is called before the first frame update
    void Start()
    {
        bm = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTurret1()
    {
        Debug.Log("Turret");
        bm.SetTurretToPlace(regularTurret);
    }

    public void SelectTurret2()
    {
        Debug.Log("Cannon");
        bm.SetTurretToPlace(cannonTurret);
    }

    public void SelectTurret3()
    {
        Debug.Log("Turret 3");
        bm.SetTurretToPlace(turret3);
    }
}
