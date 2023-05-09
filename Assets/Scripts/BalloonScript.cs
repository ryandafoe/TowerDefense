using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    private Transform target;
    private int waypointIndex = 0;
    public int moneyReward = 10;

    public float health = 10;

    private bool popped = false;
    void Start()
    {
        target = WaypointScript.waypoints[0];

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position,target.position) <= .2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= WaypointScript.waypoints.Length - 1)
        {
            PathEnd();
            return;
        }
        waypointIndex++;
        target = WaypointScript.waypoints[waypointIndex];
    }

    void PathEnd ()
    {
        PlayerStats.PlayerLives--;
        WaveSpawner.balloonsAlive--;
         Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        speed--;
        if (health <= 0 && !popped)
        {
           Pop();
        }
    }
    void Pop()
    {
        popped = true;

        PlayerStats.Money += moneyReward;

        WaveSpawner.balloonsAlive--;

        Destroy(gameObject);
    }
}
