
public interface IActionHandler
{
    void OnAction(EntityAction action);
}

public abstract class ActionHandler<T> : IActionHandler where T : EntityAction
{
    public  Entity Parent { get; private set; }
    public void SetEntity(Entity entity)
    {
        Parent = entity;
    }

    protected abstract void DoAction(T action);

    public void OnAction(EntityAction action)
    {
        if (action is T act)
            DoAction(act);
    }
    
}
