using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    MoveRight,
    MoveLeft,
    Jump,
    Pause,
    Fire,
	Stop
}

[Serializable]
public struct Action: IComparable<Action>
{
    public ActionType actionType;
    public float executionTime;

    public int CompareTo(Action other)
    {
        return - other.executionTime.CompareTo(executionTime);
    }
}
