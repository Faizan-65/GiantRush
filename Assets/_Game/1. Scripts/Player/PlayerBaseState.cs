using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void Enter(PlayerController controller);
    public abstract void OnTriggerEnter();
    public abstract void OnCollisionEnter();
    public abstract void UpdateState();
    public abstract void Exit(PlayerBaseState state);
}
