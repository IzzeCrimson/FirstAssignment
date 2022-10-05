using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    protected Transform cameraTransform;
    protected Health healthScript;
    protected HealthBar healthBarScript;
    [SerializeField] protected float timeToDestroy;
    [SerializeField] protected float damage;

    private void Update()
    {
        cameraTransform = Camera.main.transform;            
    }

}
