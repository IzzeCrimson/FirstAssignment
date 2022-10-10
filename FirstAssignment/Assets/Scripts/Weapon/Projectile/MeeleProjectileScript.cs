using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleProjectileScript : Projectile
{

    private bool _hasHit;

    void Awake()
    {
        Destroy(gameObject, _timeToDestroy);
        _hasHit = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_hasHit && collision.gameObject.GetComponent<HealthBar>())
        {
            DealDamageOnCollision(collision);
            _hasHit = true;
        }

    }

}
