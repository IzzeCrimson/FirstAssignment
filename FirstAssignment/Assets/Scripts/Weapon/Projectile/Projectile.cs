using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] public float speed;
    [SerializeField] protected float timeToDestroy;
    protected Transform cameraTransform;

    private void Update()
    {
        cameraTransform = Camera.main.transform;            
    }

}
