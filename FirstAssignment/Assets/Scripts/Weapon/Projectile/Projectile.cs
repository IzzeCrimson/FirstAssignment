using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    protected Transform cameraTransform;
    protected Health healthScript;
    protected HealthBar healthBarScript;
    [SerializeField] protected float timeToDestroy;
    [SerializeField] protected float damage;

    private void Update()
    {
        cameraTransform = Camera.main.transform;
    }

    protected void DealDamageOnCollision(Collision collision)
    {
        healthScript = collision.gameObject.GetComponent<Health>();
        healthScript.SubtractHealth(damage);
        healthBarScript = collision.gameObject.GetComponent<HealthBar>();
        healthBarScript.SetHealthValue(healthScript.currentHealth);


    }

}
