using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : Projectile
{

    public Vector3 target;
    public bool isHit;

    private void Update()
    {
       


    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT");
        Destroy(gameObject);
    }
}
