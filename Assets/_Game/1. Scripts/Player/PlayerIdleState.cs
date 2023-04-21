using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    PlayerController controller;
    public override void Enter(PlayerController controller)
    {
        Debug.Log($"Idle State");
        this.controller = controller;

        controller.swerveMotion.enabled = false;
        controller.forwardMotion.enabled = false;   
    }
    public override void UpdateState()
    {

    }


    public override void OnCollisionEnter()
    {

    }

    public override void OnTriggerEnter()
    {

    }

    public override void Exit(PlayerBaseState state)
    {
        controller.SwitchState(state);
    }
}