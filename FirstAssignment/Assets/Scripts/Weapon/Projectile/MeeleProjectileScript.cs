using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleProjectileScript : Projectile
{

    private bool hasHit;

    void Awake()
    {
        Destroy(gameObject, timeToDestroy);
        hasHit = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasHit && collision.gameObject.GetComponent<HealthBar>())
        {
            DealDamageOnCollision(collision);
            hasHit = true;
        }

    }

}
