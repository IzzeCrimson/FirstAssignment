using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCharacter : MonoBehaviour
{

    [SerializeField] private GameObject[] playableCharacters;
    [SerializeField] private int currentPlayer;
    private string cameraPositionName;
    private string cameraLookAtName;

    [SerializeField] private CinemachineVirtualCamera cinemachine;
    [SerializeField] private Camera playerCamera;
    private CameraFollow cameraFollowScript;
    private Transform _cameraPosition;
    private Transform _cameraLookAtTarget;

    InputManager inputManager;

    void Awake()
    {
        cameraPositionName = "CameraPosition";
        cameraLookAtName = "CameraLookAtTarget";
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
        _cameraPosition = playableCharacters[currentPlayer].transform.Find(cameraPositionName);
        _cameraLookAtTarget = playableCharacters[currentPlayer].transform.Find(cameraLookAtName);

        cinemachine.transform.position = _cameraPosition.position;
        cinemachine.transform.rotation = _cameraPosition.rotation;

        cinemachine.Follow = _cameraPosition.transform;
        cinemachine.LookAt = _cameraLookAtTarget.transform;
        //cinemachine.LookAt = playableCharacters[currentPlayer].transform;
    }

    private void SetNewCameraPosition()
    {
        _cameraPosition = playableCharacters[currentPlayer].transform.Find(cameraPositionName);
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
