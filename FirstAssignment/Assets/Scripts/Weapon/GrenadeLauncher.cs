using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Weapon
{

    public override void Shoot()
    {
        base.Shoot();

        GameObject grenade = Instantiate(_projectilePrefab, _spawnPoint.position, Quaternion.identity);
        grenade.GetComponent<Rigidbody>().velocity = (_target - _spawnPoint.position).normalized * _speed;
    }


}
