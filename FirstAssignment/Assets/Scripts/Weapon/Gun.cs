using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    //private Transform cameraTransform;
    private BulletScript bulletScript;
    private Vector3 target;


    private void Awake()
    {
        //cameraTransform = Camera.main.transform;
        bulletScript = bulletPrefab.GetComponent<BulletScript>();

    }

    public override void Shoot()
    {
        //base.Shoot();
        //GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0, 0, 0));
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            target = hit.point;
            
        }
        else
        {
            target = (playerCamera.transform.position + playerCamera.transform.forward * 1000);
        }

        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = (target - spawnPoint.position).normalized * speed;

       // Debug.Log("Gun Fired!");
    }

}
