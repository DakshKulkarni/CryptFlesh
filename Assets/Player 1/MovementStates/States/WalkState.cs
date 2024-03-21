using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MovementBaseState
{
    // Start is called before the first frame update
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Walking", true);
    }

    // Update is called once per frame
    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement,movement.Run);
        else if(Input.GetKeyDown(KeyCode.C)) ExitState(movement,movement.Crouch);
        else if(movement.dir.magnitude < 0.1f) ExitState(movement,movement.Idle);

        if (movement.vInput < 0) movement.currentMoveSpeed = movement.walkBackSpeed;
        else movement.currentMoveSpeed = movement.walkSpeed;
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
           // movement.previousState = this;
            //ExitState(movement,movement.Jump);
        //}
    }

    void ExitState(MovementStateManager movement, MovementBaseState state)
    { 
        movement.anim.SetBool("Walking", false);
        movement.SwitchState(state);
    }
}
