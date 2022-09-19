using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCharacter : MonoBehaviour
{

    [SerializeField] private GameObject[] playableCharacters;
    [SerializeField] private int currentPlayer;
    [SerializeField] private CinemachineVirtualCamera cinemachine;
    private Transform cameraPosition;
    private string childName;

    void Awake()
    {
        childName = "CameraPosition";
        playableCharacters[currentPlayer].GetComponent<PlayerMovement>().isCharatcerActive = true;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwapPlayer();
        }
    }

    private void SwapPlayer()
    {
        playableCharacters[currentPlayer].GetComponent<PlayerMovement>().isCharatcerActive = false;

        currentPlayer = (currentPlayer += 1) % playableCharacters.Length;
        playableCharacters[currentPlayer].GetComponent<PlayerMovement>().isCharatcerActive = true;

        SetNewCameraPosition();

    }

    private void SetNewCameraPosition()
    {
        cameraPosition = playableCharacters[currentPlayer].transform.Find(childName);
        //cinemachine.transform.position = cameraPosition.position;
        cinemachine.Follow = playableCharacters[currentPlayer].transform;
    }

}
