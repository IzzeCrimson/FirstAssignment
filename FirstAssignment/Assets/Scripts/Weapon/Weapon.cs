using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected float speed;
    protected Camera playerCamera;

    private void Start()
    {
        playerCamera = Camera.main;
    }

    public virtual void Shoot()
    {
        

    }


}
