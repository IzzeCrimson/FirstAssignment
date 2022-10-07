using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class TurnTime : MonoBehaviour
{
    static private float _setUpTimer;
    static private float _turnTimer;
    static private float _endTurnTimer;
    static private float _timer;

    static public bool isTurnSetUp;
    static public bool isTurnRunning;
    static public bool isTurnEnding;

    static private CharacterManager _characterManager;

    [SerializeField] private TextMeshProUGUI _timerText;

    private void Awake()
    {
        _characterManager = gameObject.GetComponent<CharacterManager>();
    }

    void Start()
    {
        _setUpTimer = 3;
        _turnTimer = 30;
        _endTurnTimer = 5;
        _timer = _setUpTimer;

        isTurnSetUp = true;
        isTurnRunning = false;
        isTurnEnding = false;
    }

    
    void Update()
    {
        TimerCountDown();
    }

    static public void EndTurnSetUp()
    {
        Debug.Log("Preperations has ended");
        _timer = _turnTimer;
        isTurnSetUp = false;
        isTurnRunning = true;

    }

    static public void EndTurnTimer()
    {
        Debug.Log("Turn has ended");
        _timer = _endTurnTimer;
        isTurnRunning = false;
        isTurnEnding = true;

    }

    static public void EndTurnEnding()
    {
        Debug.Log("Swapping player");
        _timer = _setUpTimer;
        isTurnEnding = false;
        isTurnSetUp = true;
        _characterManager.SwapPlayer();

    }

    void TimerCountDown()
    {
        _timer -= Time.deltaTime;

        if (isTurnSetUp && _timer <= 0)
        {
            EndTurnSetUp();

        }

        if (isTurnRunning && _timer <= 0)
        {
            EndTurnTimer();

        }

        if (isTurnEnding && _timer <= 0)
        {
            EndTurnEnding();

        }

        _timerText.text = Mathf.Round(_timer * 1).ToString();
    }

}
