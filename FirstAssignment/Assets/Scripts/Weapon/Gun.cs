using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    private Transform cameraTransform;
    private float missDistance;
    private BulletScript bulletScript;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        missDistance = 50;
    }

    public override void Shoot()
    {
        //base.Shoot();
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

        //Debug.Log("Gun Fired!");
    }

}
