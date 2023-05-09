using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//FingerDof nearest target and hoot at target

public class TurretScript : MonoBehaviour
{
    //attribures
    private Transform target;
    public float range = 5f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    //Unity set up items
    public float turnSpeed = 10f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        //call update taget 2 times a seccond
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        //rotate the top, target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotatioon = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotatioon, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //shooting. ecery seccond the you can fire 2 time
        if(fireCountdown <= 0f)
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
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletScript bullet = bulletGO.GetComponent<BulletScript>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    //range only drawn when turret is slelected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void IncreseFireRate()
    {
        fireRate += 1;
    }
}
