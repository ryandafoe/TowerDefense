using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float Money;
    public int startMoney = 400;
    
    public static int PlayerLives;
    public int startLives = 20;

    public static int Rounds;


    void Start ()
    {
        Money = startMoney;
        PlayerLives = startLives;
        Rounds = 0;
    }



}
