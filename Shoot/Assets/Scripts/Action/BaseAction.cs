using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAction
{
    public int ID { get; private set; }
    public ActionType Type { get; private set; }

    public BaseAction(int id, ActionType type)
    {
        ID = id;
        Type = type;
    }
}
