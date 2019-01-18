using UnityEngine;

public enum MovementType
{
    Speed,
    Direction,
    Stop,
    AdjustPosition,
    Teleport,
}

public class MovementAction : EntityAction
{
    public MovementType Type;
    public float FValue;
    public Vector3 VecValue;
}

public partial class MovementHandler : ActionHandler<MovementAction>
{
    public float StartTime { get; private set; }
    public float CurrSpeed { get; private set; }
    public Vector3 StartPos { get; private set; }
    public Vector3 CurrDirection { get; private set; }

    protected override void DoAction(MovementAction action)
    {
        switch (action.Type)
        {
            case MovementType.Speed:
                UpdateSpeed(action.Time, action.FValue);
                break;
            case MovementType.Direction:
                UpdateDirection(action.Time, action.VecValue);
                break;
            case MovementType.Stop:
                Reset(action.Time, action.VecValue, CurrDirection, 0);
                break;
            case MovementType.AdjustPosition:
                Reset(action.Time, action.VecValue, CurrDirection, 0);
                break;
            case MovementType.Teleport:
                Reset(action.Time, action.VecValue, CurrDirection, 0);
                Parent.Obj.transform.position = action.VecValue;
                break;
            default:
                break;
        }
    }

    public Vector3 GetPosition(float time)
    {
        if (CurrSpeed == 0)
            return StartPos;
        return (time - StartTime) * CurrSpeed * CurrDirection + StartPos;
    }

    private void UpdateSpeed(float time, float speed)
    {
        StartPos = GetPosition(time);
        StartTime = time;
        CurrSpeed = speed;
    }

    private void UpdateDirection(float time, Vector3 direction)
    {
        StartPos = GetPosition(time);
        StartTime = time;
        CurrDirection = direction.normalized;
    }

    private void Reset(float time, Vector3 pos, Vector3 direction, float speed)
    {
        StartTime = time;
        StartPos = pos;
        CurrDirection = direction.normalized;
        CurrSpeed = speed;
    }
}
