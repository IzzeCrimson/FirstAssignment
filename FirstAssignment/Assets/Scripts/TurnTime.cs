using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class TurnTime : MonoBehaviour
{
    static private float setUpTimer;
    static private float turnTimer;
    static private float endTurnTimer;
    static private float timer;

    static public bool isTurnSetUp;
    static public bool isTurnRunning;
    static public bool isTurnEnding;

    static CharacterManager characterManager;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float floatSerilalizationHelper;

    private void Awake()
    {
        characterManager = gameObject.GetComponent<CharacterManager>();
    }

    void Start()
    {
        setUpTimer = 5;
        turnTimer = 30;
        endTurnTimer = 5;
        timer = setUpTimer;

        isTurnSetUp = true;
        isTurnRunning = false;
        isTurnEnding = false;
    }

    
    void Update()
    {
        TimerCountDown();
        floatSerilalizationHelper = timer;
    }

    static public void EndTurnSetUp()
    {
        Debug.Log("Preperations has ended");
        timer = turnTimer;
        isTurnSetUp = false;
        isTurnRunning = true;

    }

    static public void EndTurnTimer()
    {
        Debug.Log("Turn has ended");
        timer = endTurnTimer;
        isTurnRunning = false;
        isTurnEnding = true;

    }

    static public void EndTurnEnding()
    {
        Debug.Log("Swapping player");
        timer = setUpTimer;
        isTurnEnding = false;
        isTurnSetUp = true;
        characterManager.SwapPlayer();

    }

    void TimerCountDown()
    {
        timer -= Time.deltaTime;

        if (isTurnSetUp && timer <= 0)
        {
            EndTurnSetUp();

        }

        if (isTurnRunning && timer <= 0)
        {
            EndTurnTimer();

        }

        if (isTurnEnding && timer <= 0)
        {
            EndTurnEnding();

        }

        timerText.text = Mathf.Round(timer * 1).ToString();
    }

}
