using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform spawnPoint;

    public virtual void Shoot()
    {
        

    }


}
