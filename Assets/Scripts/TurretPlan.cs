using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
public class TurretPlan
{
    public GameObject prefab;
    public float cost;
    public int upgradeCost;
    //public GameObject upgradedPrefab;

    public float GetSellAmount()
    {
        return cost / 2;
    }

}

