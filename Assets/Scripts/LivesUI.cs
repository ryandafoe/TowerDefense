using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{

    public TextMeshProUGUI lives; //text for lives

    // Update is called once per frame
    void Update()
    {
        lives.text = "Lives: " + PlayerStats.PlayerLives.ToString(); // update the value constantly
    }
    
}
