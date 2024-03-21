public abstract class ActionBaseState 
{
    // Start is called before the first frame update
    public abstract void EnterState(ActionStateManager actions);

    // Update is called once per frame
    public abstract void UpdateState(ActionStateManager actions);
}
