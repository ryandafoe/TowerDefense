using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText; // reference to the Text component on the canvas

    private void Update()
    {
        moneyText.text = "Money: " + PlayerStats.Money.ToString(); // update the value constantly
    }
}

