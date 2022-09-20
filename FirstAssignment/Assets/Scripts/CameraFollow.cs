using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;

    void Start()
    {
        SetUp();
    }

    void Update()
    {
        cameraPosition = targetObject.position + initalOffset;
        transform.position = cameraPosition;
    }

    public void SetUp()
    {
        initalOffset = transform.position - targetObject.position;

    }

}
