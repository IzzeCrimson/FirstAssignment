using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : Projectile
{
    [SerializeField] private ParticleSystem _effect;

    void Awake()
    {
        Destroy(gameObject, _timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HealthBar>())
        {
            Instantiate(_effect, gameObject.transform.position, Quaternion.identity);
            DealDamageOnCollision(collision);
        
        }
            Destroy(gameObject);
    }
}
