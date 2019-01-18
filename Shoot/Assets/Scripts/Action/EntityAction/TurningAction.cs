using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningAction : EntityAction
{
    public float Value;
}


public partial class TurningHandler : ActionHandler<TurningAction>
{
    protected override void DoAction(TurningAction action)
    {

    }
}