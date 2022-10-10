using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] protected GameObject _projectilePrefab;
    [SerializeField] protected Transform _spawnPoint;
    [SerializeField] protected float _speed;
    protected Vector3 _target;
    protected Camera _playerCamera;

    private void Start()
    {
        _playerCamera = Camera.main;
    }

    public virtual void Shoot()
    {
        Ray ray = _playerCamera.ViewportPointToRay(new Vector3(0, 0, 0));
        RaycastHit hit;
        if (Physics.Raycast(_playerCamera.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            _target = hit.point;

        }
        else
        {
            _target = (_playerCamera.transform.position + _playerCamera.transform.forward * 1000);
        }

    }


}
