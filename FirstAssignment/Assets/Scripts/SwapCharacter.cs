using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCharacter : MonoBehaviour
{

    [SerializeField] static private GameObject[] playableCharacters;
    [SerializeField] static private int currentPlayer;

    [SerializeField] static private CinemachineVirtualCamera cinemachine;
    //[SerializeField] private Camera playerCamera;


    InputManager inputManager;

    void Awake()
    {
        playableCharacters[currentPlayer].GetComponent<PlayerControlls>().isCharatcerActive = true;

        inputManager = new InputManager();

    }

    void Update()
    {
        
    }

    static private void SwapPlayer()
    {
        playableCharacters[currentPlayer].GetComponent<PlayerControlls>().isCharatcerActive = false;

        currentPlayer = (currentPlayer + 1) % playableCharacters.Length;
        SetNewCameraPositionCinemachine();
        playableCharacters[currentPlayer].GetComponent<PlayerControlls>().isCharatcerActive = true;

        
    }

    static private void SetNewCameraPositionCinemachine()
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
