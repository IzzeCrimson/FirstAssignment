using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Weapon
{

    public override void Shoot()
    {
        base.Shoot();

        GameObject fist = Instantiate(_projectilePrefab, _spawnPoint.position, Quaternion.identity);
        fist.GetComponent<Rigidbody>().velocity = (_target - _spawnPoint.position).normalized * _speed;

    }



}
