using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : Projectile
{
    private bool isTimerActive;
    private float time;
    [SerializeField] private float timeThreshHold;
    [SerializeField] private float radius;
    [SerializeField] private float minDamage;
    [SerializeField] private float maxDamage;
    [SerializeField] private ParticleSystem explosionPrefab;
    private Collider[] targets;
    private float distance;

    private void Start()
    {
        isTimerActive = false;
        timeThreshHold = 3f;
    }

    void Update()
    {
        if (isTimerActive)
        {
            time += Time.deltaTime;

        }

        if (time >= timeThreshHold)
        {
            Explode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isTimerActive = true;


    }

    private void Explode()
    {
        Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        targets = Physics.OverlapSphere(gameObject.transform.position, radius);

        for (int i = 0; i < targets.Length; i++)
        {
            distance = Vector3.Distance(gameObject.transform.position, targets[i].transform.position);
            damage = Mathf.FloorToInt(Mathf.Lerp(maxDamage, minDamage, distance / radius));

            if (targets[i].TryGetComponent<Health>(out Health health))
            {
                health.SubtractHealth(damage);
            }
            if (targets[i].TryGetComponent<HealthBar>(out HealthBar healthBar))
            {
                healthBar.SetHealthValue(health.currentHealth);
            }
        }

        Destroy(gameObject);
    }


}
