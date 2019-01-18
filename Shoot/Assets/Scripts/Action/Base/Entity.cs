using System;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public GameObject Obj { get; private set; }
    public int ID { get; private set; }
    
    private readonly Dictionary<Type, IActionHandler> handlers = new Dictionary<Type, IActionHandler>();
    public void DOAction(EntityAction action)
    {
        if (handlers.TryGetValue(action.GetType(), out IActionHandler handler))
        {
            handler.OnAction(action);
        }
    }

    public void AddActionHandler<THandler, TAction>(bool replace = false)where TAction : EntityAction where THandler : ActionHandler<TAction>, new()
    {
        THandler handler = new THandler();
        Type actType = typeof(TAction);
#if UNITY_EDITOR
        if (!replace && handlers.ContainsKey(actType))
        {
            Debug.LogError("Action 的处理函数重复注册 type = " + actType.Name);
            return;
        }
#endif
        if (replace)
            handlers.Remove(actType);
        handlers.Add(actType, handler);
    }
    
}
