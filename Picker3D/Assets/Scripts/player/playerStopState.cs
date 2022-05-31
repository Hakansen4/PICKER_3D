using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStopState : playerBaseState
{
    public override void EnterState(playerStateManager charachter)
    {
        charachter.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public override void OnTriggerEnter(playerStateManager charachter, Collider collisionInfo)
    {
    }

    public override void UpdateState(playerStateManager charachter)
    {
    }
}
