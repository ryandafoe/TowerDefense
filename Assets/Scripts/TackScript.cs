using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackScript : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public GameObject impactEffect;

    public int moneyReward = 10; //reward for destroying a balloon

    public float s = 15.0f;
    public float distance = 5.0f;

    public int damage = 10;

    void Start()
    {
        StartCoroutine(MoveAndDestroyCoroutine());
    }

    IEnumerator MoveAndDestroyCoroutine()
    {
        // Move the GameObject forward for a certain distance
        float distanceMoved = 0.0f;
        while (distanceMoved < distance)
        {
            transform.position += transform.forward * s * Time.deltaTime;
            distanceMoved += s * Time.deltaTime;
            yield return null;
        }

        // Wait for 1 second before destroying the GameObject
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

    //set the target
    public void Seek(Transform _target)
    {
        target = _target;
    }
    public void ShootSpikes()
    {
        target.transform.position = target.transform.forward * 5 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        //make it so that if the target changes, it is destroyed
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //find the direction of the target
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            //we have hit somthing
            HitTarget();
            return;
        }

        //move if we havnt hit it
        //transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

            Damage(target);

        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        BalloonScript b = enemy.GetComponent<BalloonScript>();

        if (b != null)
        {
            b.TakeDamage(damage);
        }
    }
}
