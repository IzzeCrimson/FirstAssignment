using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCharacter : MonoBehaviour
{

    [SerializeField] private GameObject[] playableCharacters;
    [SerializeField] private int currentPlayer;
    private string childName;

    [SerializeField] private CinemachineVirtualCamera cinemachine;
    [SerializeField] private Camera playerCamera;
    private CameraFollow cameraFollowScript;
    private Transform _cameraPosition;

    InputManager inputManager;

    void Awake()
    {
        childName = "CameraPosition";
        playableCharacters[currentPlayer].GetComponent<PlayerMovement>().isCharatcerActive = true;
        cameraFollowScript = playerCamera.GetComponent<CameraFollow>();
        inputManager = new InputManager();

    }

    void Update()
    {
        if (inputManager.PlayerControlls.EndTurn.triggered)
        {
            SwapPlayer();
        }
    }

    private void SwapPlayer()
    {
        playableCharacters[currentPlayer].GetComponent<PlayerMovement>().isCharatcerActive = false;

        currentPlayer = (currentPlayer += 1) % playableCharacters.Length;
        playableCharacters[currentPlayer].GetComponent<PlayerMovement>().isCharatcerActive = true;

        SetNewCameraPositionCinemachine();

    }

    private void SetNewCameraPositionCinemachine()
    {
        _cameraPosition = playableCharacters[currentPlayer].transform.Find(childName);

        cinemachine.transform.position = _cameraPosition.position;
        cinemachine.transform.rotation = _cameraPosition.rotation;

        cinemachine.Follow = playableCharacters[currentPlayer].transform;
    }

    private void SetNewCameraPosition()
    {
        _cameraPosition = playableCharacters[currentPlayer].transform.Find(childName);
        playerCamera.transform.position = _cameraPosition.position;
        playerCamera.transform.rotation = _cameraPosition.rotation;
        cameraFollowScript.targetObject = playableCharacters[currentPlayer].transform;
        cameraFollowScript.CameraSetUp();
    }

    private void OnEnable()
    {

        inputManager.Enable();

    }

    private void OnDisable()
    {

        inputManager.Disable();

    }

}
