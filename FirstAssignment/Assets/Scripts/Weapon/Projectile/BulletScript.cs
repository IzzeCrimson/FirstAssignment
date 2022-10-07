using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : Projectile
{
    [SerializeField] private ParticleSystem effect;

    void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HealthBar>())
        {
            Instantiate(effect, gameObject.transform.position, Quaternion.identity);
            DealDamageOnCollision(collision);
        
        }
            Destroy(gameObject);
    }
}
