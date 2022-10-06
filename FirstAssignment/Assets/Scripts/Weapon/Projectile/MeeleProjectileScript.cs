using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleProjectileScript : Projectile
{

    void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HealthBar>())
        {
            DealDamageOnCollision(collision);

        }

    }

}
