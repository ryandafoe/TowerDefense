using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int balloonsAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public static bool win = false;

    public bool nextWave = false;

    private int waveNum = 0;


    void Update()
    {
        //Debug.Log(balloonsAlive);
        if (balloonsAlive > 0)
        {
            return;
        }

        if (waveNum == waves.Length)
        {
            this.enabled = false;
        }

        if (balloonsAlive <= 0f && nextWave == true)
        {
            PlayerStats.Money += 50;
            StartCoroutine(SpawnWave());
            nextWave = false;
            return;
        }

        if (waveNum == waves.Length && balloonsAlive <= 0)
        {
            win = true;
        }
    }
    
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveNum];
        balloonsAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.balloon);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveNum++;

    }
    
    void SpawnEnemy(GameObject balloon)
    {
        Instantiate(balloon, spawnPoint.position, spawnPoint.rotation);
    }

    public void StartWave()
    {
        nextWave = true;
    }

}