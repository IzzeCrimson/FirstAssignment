using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
   


    private void Awake()
    {

    }

    public override void Shoot()
    {
        base.Shoot();

        GameObject bullet = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = (target - spawnPoint.position).normalized * speed;

       // Debug.Log("Gun Fired!");
    }

}
