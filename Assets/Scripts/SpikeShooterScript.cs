using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpikeShooterScript : MonoBehaviour
{
    //attribures
    private Transform target;
    public float range = 5f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    //Unity set up items
    public float turnSpeed = 10f;
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;
    public Transform firePoint6;
    public Transform firePoint7;
    public Transform firePoint8;



    // Start is called before the first frame update
    void Start()
    {
        //call update taget 2 times a seccond
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }


        //shooting. ecery seccond the you can fire 2 time
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    //search through all targets marked as enemy, check if losoest oone is within range
    // if it is set the target that object
    void UpdateTarget()
    {
        GameObject[] balloons = GameObject.FindGameObjectsWithTag(enemyTag);

        //store shortest dsitance to enemy
        float shortestDistance = Mathf.Infinity;
        GameObject nearestBalloon = null;

        //for each enemy, get the distnace, and if its distance is shorter we set the new one to this.
        foreach (GameObject enemy in balloons)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestBalloon = enemy;
            }
        }

        //here is the nearest enemy
        if (nearestBalloon != null && shortestDistance <= range)
        {
            target = nearestBalloon.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        //Debug.Log("SHOOOT");
        GameObject bulletGO1 = (GameObject)Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        GameObject bulletGO2 = (GameObject)Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        GameObject bulletGO3 = (GameObject)Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
        GameObject bulletGO4 = (GameObject)Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
        GameObject bulletGO5 = (GameObject)Instantiate(bulletPrefab, firePoint5.position, firePoint5.rotation);
        GameObject bulletGO6 = (GameObject)Instantiate(bulletPrefab, firePoint6.position, firePoint6.rotation);
        GameObject bulletGO7 = (GameObject)Instantiate(bulletPrefab, firePoint7.position, firePoint7.rotation);
        GameObject bulletGO8 = (GameObject)Instantiate(bulletPrefab, firePoint8.position, firePoint8.rotation);

        TackScript tack1 = bulletGO1.GetComponent<TackScript>();
        TackScript tack2 = bulletGO2.GetComponent<TackScript>();
        TackScript tack3 = bulletGO3.GetComponent<TackScript>();
        TackScript tack4 = bulletGO4.GetComponent<TackScript>();
        TackScript tack5 = bulletGO5.GetComponent<TackScript>();
        TackScript tack6 = bulletGO6.GetComponent<TackScript>();
        TackScript tack7 = bulletGO7.GetComponent<TackScript>();
        TackScript tack8 = bulletGO8.GetComponent<TackScript>();

        TackScript[] bulletList = new TackScript[8];

        bulletList[0] = tack1;
        bulletList[1] = tack2;
        bulletList[2] = tack3;
        bulletList[3] = tack4;
        bulletList[4] = tack5;
        bulletList[5] = tack6;
        bulletList[6] = tack7;
        bulletList[7] = tack8;

        for (int i = 0; i < bulletList.Length; i++)
        {
            if (bulletList[i] != null)
            {
                bulletList[i].Seek(target);
            }
        }
    }

    public void UpgradeRange()
    {
        range = range + 2;
        Debug.Log("Range Increased");
        return;
    }
    public void UpgardeFireRate()
    {
        fireRate++;
        return;
    }
    public void IncreseFireRate()
    {
        fireRate += 1;
    }
    //range only drawn when turret is slelected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
