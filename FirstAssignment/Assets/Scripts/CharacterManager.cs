using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    [SerializeField] public List<GameObject> blueTeamList;
    [SerializeField] public List<GameObject> redTeamList;
    [SerializeField] private int _currentBluePlayer;
    [SerializeField] private int _currentRedPlayer;


    [SerializeField] private CinemachineVirtualCamera _cinemachine;
    //[SerializeField] private Camera playerCamera;

    private bool _isBlueTurn;
    private GameOver _gameOver;

    void Awake()
    {
        blueTeamList[_currentBluePlayer].GetComponent<PlayerController>().isCharatcerActive = true;
        _gameOver = gameObject.GetComponent<GameOver>();
        _isBlueTurn = true;
        _currentBluePlayer = 0;
        _currentRedPlayer = -1;
    }

    public void SwapPlayer()
    {

        blueTeamList = CleanList(blueTeamList);
        redTeamList = CleanList(redTeamList);

        CheckForWinner(blueTeamList, "Red");
        CheckForWinner(redTeamList, "Blue");

        if (!GameOver.isGameOver)
        {


            if (_isBlueTurn)
            {
                blueTeamList[_currentBluePlayer].GetComponent<PlayerController>().isCharatcerActive = false;

                _currentRedPlayer = (_currentRedPlayer + 1) % redTeamList.Count;
                redTeamList[_currentRedPlayer].GetComponent<PlayerController>().isCharatcerActive = true;

                SetNewCameraPositionCinemachine(redTeamList[_currentRedPlayer]);
                _isBlueTurn = false;
            }
            else
            {
                redTeamList[_currentRedPlayer].GetComponent<PlayerController>().isCharatcerActive = false;

                _currentBluePlayer = (_currentBluePlayer + 1) % blueTeamList.Count;
                blueTeamList[_currentBluePlayer].GetComponent<PlayerController>().isCharatcerActive = true;

                SetNewCameraPositionCinemachine(blueTeamList[_currentBluePlayer]);
                _isBlueTurn = true;
            }

        }

    }

    private void SetNewCameraPositionCinemachine(GameObject player)
    {
        //cinemachine.transform.rotation = playableCharacters[currentPlayer].transform.rotation;
        _cinemachine.Follow = player.transform;
        _cinemachine.LookAt = player.transform;

    }

    private List<GameObject> CleanList(List<GameObject> players)
    {
        for (int i = players.Count - 1; i > -1; i--)
        {
            if (players[i] == null)
            {
                players.RemoveAt(i);
            }
        }

        return players;
    }

    private void CheckForWinner(List<GameObject> team, string oppositeTeamColor)
    {
        if (team.Count == 0)
        {
            Debug.Log(oppositeTeamColor + " Team Win!");
            GameOver.isGameOver = true;
            _gameOver.WinnerIsDecided(oppositeTeamColor);
        }
    }


}
