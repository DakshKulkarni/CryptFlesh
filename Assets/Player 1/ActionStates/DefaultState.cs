using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : ActionBaseState

{
    // Start is called before the first frame update
    public override void EnterState(ActionStateManager actions)
    {
        
    }

    // Update is called once per frame
    public override void UpdateState(ActionStateManager actions)
    {
        actions.RHandAim.weight = Mathf.Lerp(actions.RHandAim.weight, 1, 10 * Time.deltaTime);
        actions.LhandIK.weight = Mathf.Lerp(actions.LhandIK.weight, 1, 10 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.R) && CanReload(actions))
        {
            actions.SwitchState(actions.Reload);
        }
    }

    bool CanReload(ActionStateManager action)
    {
        if (action.ammo.currentAmmo == action.ammo.clipSize) return false;
        else if (action.ammo.extraAmmo == 0) return false;
        else return true;
    }
}
