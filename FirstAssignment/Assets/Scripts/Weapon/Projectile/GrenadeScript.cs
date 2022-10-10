using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : Projectile
{
    private bool _isTimerActive;
    private float _time;
    [SerializeField] private float _timeThreshHold;
    [SerializeField] private float _radius;
    [SerializeField] private float _minDamage;
    [SerializeField] private float _maxDamage;
    [SerializeField] private ParticleSystem _explosionPrefab;
    private Collider[] _targets;
    private float _distance;

    private void Start()
    {
        _isTimerActive = false;
        _timeThreshHold = 3f;
    }

    void Update()
    {
        if (_isTimerActive)
        {
            _time += Time.deltaTime;

        }

        if (_time >= _timeThreshHold)
        {
            Explode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isTimerActive = true;


    }

    private void Explode()
    {
        Instantiate(_explosionPrefab, gameObject.transform.position, Quaternion.identity);
        _targets = Physics.OverlapSphere(gameObject.transform.position, _radius);

        for (int i = 0; i < _targets.Length; i++)
        {
            _distance = Vector3.Distance(gameObject.transform.position, _targets[i].transform.position);
            _damage = Mathf.FloorToInt(Mathf.Lerp(_maxDamage, _minDamage, _distance / _radius));

            if (_targets[i].TryGetComponent<Health>(out Health health))
            {
                health.SubtractHealth(_damage);
            }
            if (_targets[i].TryGetComponent<HealthBar>(out HealthBar healthBar))
            {
                healthBar.SetHealthValue(health.currentHealth);
            }
        }

        Destroy(gameObject);
    }


}
