using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundsUI : MonoBehaviour
{

    public TextMeshProUGUI Rounds; //text for lives

    // Update is called once per frame
    void Update()
    {
        Rounds.text = "Round: " + PlayerStats.Rounds.ToString(); // update the value constantly
    }
    
}
