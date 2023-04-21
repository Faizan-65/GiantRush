using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    PlayerController controller;
    public override void Enter(PlayerController controller)
    {
        Debug.Log($"Walk State");
        this.controller = controller;

        controller.swerveMotion.enabled = true;
        controller.forwardMotion.enabled = true;
    }
    public override void UpdateState()
    {
        controller.forwardMotion.Move();
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