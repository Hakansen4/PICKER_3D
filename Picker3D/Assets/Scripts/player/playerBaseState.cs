using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class playerBaseState
{
    public abstract void EnterState(playerStateManager charachter);

    public abstract void UpdateState(playerStateManager charachter);

    public abstract void OnTriggerEnter(playerStateManager charachter, Collider collisionInfo);
}
