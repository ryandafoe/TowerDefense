using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public TextMeshProUGUI WinningText;

    void Update()
    {
        if(WaveSpawner.win == true)
        {
            WinningText.text = "YOU WIN!!!";
            roundsText.text = PlayerStats.Rounds.ToString();
        }
        else
        {
            WinningText.text = "YOU LOSE!!!";
            roundsText.text = PlayerStats.Rounds.ToString();
        }
        
        
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
