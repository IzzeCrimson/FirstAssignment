using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected float speed;
    protected Vector3 target;
    protected Camera playerCamera;

    private void Start()
    {
        playerCamera = Camera.main;
    }

    public virtual void Shoot()
    {
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

    }


}
