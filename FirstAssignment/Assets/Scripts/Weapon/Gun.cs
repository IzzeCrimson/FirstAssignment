using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{

    public override void Shoot()
    {
        base.Shoot();

        GameObject bullet = Instantiate(_projectilePrefab, _spawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = (_target - _spawnPoint.position).normalized * _speed;

       // Debug.Log("Gun Fired!");
    }

}
