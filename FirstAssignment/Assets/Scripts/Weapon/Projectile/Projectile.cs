using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    [SerializeField] protected float timeToDestroy;
    protected Transform cameraTransform;
    [SerializeField] protected float damage;

    private void Update()
    {
        cameraTransform = Camera.main.transform;            
    }

}
