using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public GameObject impactEffect;

    public int moneyReward = 10; //reward for destroying a balloon

    public int damage = 10;

    public float explosionRadius = 0f;

    //set the target
    public void Seek(Transform nextTarget)
    {
        target = nextTarget;
    }


    // Update is called once per frame
    void Update()
    {
        //make it so that if the target changes, it is destroyed
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        //find the direction of the target
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            //we have hit somthing
            HitTarget();
            return;
        }

        //move if we havnt hit it
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform balloon)
    {
        BalloonScript b = balloon.GetComponent<BalloonScript>();

        if (b != null)
        {
            b.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
