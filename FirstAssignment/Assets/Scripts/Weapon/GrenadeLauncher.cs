using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Weapon
{

    public override void Shoot()
    {
        base.Shoot();

        GameObject grenade = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        grenade.GetComponent<Rigidbody>().velocity = (target - spawnPoint.position).normalized * speed;
    }


}
