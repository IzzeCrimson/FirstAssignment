using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TurnTime : MonoBehaviour
{
    static private float setUpTimer;
    static private float turnTimer;
    static private float endTurnTimer;
    static public bool isTurnRunning;
    bool isTurnEnding;

    void Start()
    {
        TimerSetUp();
    }

    
    void Update()
    {

    }

    void TimerSetUp()
    {
        setUpTimer = 10;
        turnTimer = 60;
        endTurnTimer = 5;

    }

    void SetUpTimerCountDown()
    {
        setUpTimer -= Time.fixedDeltaTime;

        if (setUpTimer <= 0)
        {
            
        }

    }

}
