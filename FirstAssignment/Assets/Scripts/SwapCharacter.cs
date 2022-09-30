using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCharacter : MonoBehaviour
{

    [SerializeField] private GameObject[] playableCharacters;
    [SerializeField] private int currentPlayer;

    [SerializeField] private CinemachineVirtualCamera cinemachine;
    //[SerializeField] private Camera playerCamera;


    InputManager inputManager;

    void Awake()
    {
        playableCharacters[currentPlayer].GetComponent<PlayerMovement>().isCharatcerActive = true;

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
        //cinemachine.transform.rotation = playableCharacters[currentPlayer].transform.rotation;
        cinemachine.Follow = playableCharacters[currentPlayer].transform;
        cinemachine.LookAt = playableCharacters[currentPlayer].transform;

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
