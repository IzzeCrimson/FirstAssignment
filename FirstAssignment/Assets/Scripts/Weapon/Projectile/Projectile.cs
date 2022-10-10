using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    protected Transform _cameraTransform;
    protected Health _healthScript;
    protected HealthBar _healthBarScript;
    [SerializeField] protected float _timeToDestroy;
    [SerializeField] protected float _damage;

    private void Update()
    {
        _cameraTransform = Camera.main.transform;
    }

    protected void DealDamageOnCollision(Collision collision)
    {
        _healthScript = collision.gameObject.GetComponent<Health>();
        _healthScript.SubtractHealth(_damage);
        _healthBarScript = collision.gameObject.GetComponent<HealthBar>();
        _healthBarScript.SetHealthValue(_healthScript.currentHealth);


    }

}
