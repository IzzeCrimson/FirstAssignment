using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Weapon
{

    public override void Shoot()
    {
        base.Shoot();

        GameObject fist = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        fist.GetComponent<Rigidbody>().velocity = (target - spawnPoint.position).normalized * speed;

    }



}
