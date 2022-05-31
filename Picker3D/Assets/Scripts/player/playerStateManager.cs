using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateManager : MonoBehaviour
{
    public static playerStateManager instance;

    public PlayerData Playerdata;

    #region States
    public playerBaseState CurrentState;
    public playerStopState StopState = new playerStopState();
    public playerRunState RunState = new playerRunState();
    #endregion

    public collectedBalls Balls;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        CurrentState = RunState;
        CurrentState.EnterState(this);
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        CurrentState.OnTriggerEnter(this, collisionInfo);
    }
    void FixedUpdate()
    {
        CurrentState.UpdateState(this);
    }
    public void SwitchState(playerBaseState state)
    {
        CurrentState = state;
        state.EnterState(this);
    }
}
