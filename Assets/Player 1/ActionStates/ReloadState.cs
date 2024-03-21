using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadState : ActionBaseState

{
    // Start is called before the first frame update
    public override void EnterState(ActionStateManager actions)
    {
        actions.RHandAim.weight = 0;
        actions.LhandIK.weight = 0;
        actions.anim.SetTrigger("Reload");
    }

    // Update is called once per frame
    public override void UpdateState(ActionStateManager actions)
    {

    }
}
