using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> blueTeamCharacters;
    [SerializeField] private List<GameObject> redTeamCharacters;
    [SerializeField] private int currentBluePlayer;
    [SerializeField] private int currentRedPlayer;


    [SerializeField] private CinemachineVirtualCamera cinemachine;
    //[SerializeField] private Camera playerCamera;

    private bool isBlueTurn;

    InputManager inputManager;

    void Awake()
    {
        blueTeamCharacters[currentBluePlayer].GetComponent<PlayerControlls>().isCharatcerActive = true;
        isBlueTurn = true;
        inputManager = new InputManager();
        currentBluePlayer = 0;
        currentRedPlayer = -1;
    }

    void Update()
    {
        if (inputManager.PlayerControlls.EndTurn.triggered)
        {
            SwapPlayer();
            
        }
    }

    public void SwapPlayer()
    {
        if (isBlueTurn)
        {
            blueTeamCharacters[currentBluePlayer].GetComponent<PlayerControlls>().isCharatcerActive = false;

            currentRedPlayer = (currentRedPlayer + 1) % redTeamCharacters.Count;
            redTeamCharacters[currentRedPlayer].GetComponent<PlayerControlls>().isCharatcerActive = true;

            SetNewCameraPositionCinemachine(redTeamCharacters[currentRedPlayer]);
            isBlueTurn = false;
        }
        else
        {
            redTeamCharacters[currentRedPlayer].GetComponent<PlayerControlls>().isCharatcerActive = false;

            currentBluePlayer = (currentBluePlayer + 1) % blueTeamCharacters.Count;
            blueTeamCharacters[currentBluePlayer].GetComponent<PlayerControlls>().isCharatcerActive = true;

            SetNewCameraPositionCinemachine(blueTeamCharacters[currentBluePlayer]);
            isBlueTurn = true;
        }


    }

    private void SetNewCameraPositionCinemachine(GameObject player)
    {
        //cinemachine.transform.rotation = playableCharacters[currentPlayer].transform.rotation;
        cinemachine.Follow = player.transform;
        cinemachine.LookAt = player.transform;

    }

    public void RemoveCharacter(GameObject player)
    {
        if (player.GetComponent<PlayerControlls>())
        {
            PlayerControlls playerControlls = player.GetComponent<PlayerControlls>();

            if (playerControlls.isCharacterBlue)
            {
                for (int i = 0; i < blueTeamCharacters.Count; i++)
                {
                    if (blueTeamCharacters[i] == player.gameObject)
                    {
                        blueTeamCharacters.RemoveAt(i);
                    }
                }

            }



        }

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
