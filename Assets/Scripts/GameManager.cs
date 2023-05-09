using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnd = false;

    public GameObject gameOverUI;

    void Start ()
    {
        gameEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameEnd)
            return;

        if(PlayerStats.PlayerLives <= 0 || WaveSpawner.win == true)
        {
            EndGame();
            WaveSpawner.win = false;
        }
    }

    void EndGame()
    {
        gameEnd = true;
        gameOverUI.SetActive(true);
    }
}
