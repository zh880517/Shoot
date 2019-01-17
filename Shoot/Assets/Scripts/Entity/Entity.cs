using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity
{
    public GameObject Obj { get; private set; }
    public int ID { get; private set; }
    private Dictionary<ActionType, Action<BaseAction>> onActions = new Dictionary<ActionType, Action<BaseAction>>();
    public void DOAction(BaseAction action)
    {
        if (onActions.TryGetValue(action.Type, out Action<BaseAction> func))
        {
            func(action);
        }
    }

    protected void Regist<T>(ActionType type, Action<T> func) where T : BaseAction
    {
#if UNITY_EDITOR
        if (func == null)
        {
            Debug.LogError("Action 的处理函数不能为空");
            return;
        }
        var classType = ActionToType.TypeToClassType(type);
        if (typeof(T) != classType)
        {
            Debug.LogError("Action 的处理函数参数类型和绑定的类型不符");
            return;
        }
#endif
        onActions.Add(type, (act)=>{
            T realAct = act as T;
            func(realAct);
        });
    }
}
