using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : Projectile
{

    private void Update()
    {

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HealthBar>())
        {
            healthScript = collision.gameObject.GetComponent<Health>();
            healthScript.SubtractHealth(damage);
            healthBarScript = collision.gameObject.GetComponent<HealthBar>();
            healthBarScript.SetHealthValue(healthScript.currentHealth);
            
        }


        Destroy(gameObject);
    }
}
