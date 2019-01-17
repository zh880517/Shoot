using System;
using System.Collections.Generic;

public static class ActionToType
{
    private static readonly Dictionary<ActionType, Type> typeMap = new Dictionary<ActionType, Type>()
    {

    };

    public static Type TypeToClassType(ActionType type)
    {
        typeMap.TryGetValue(type, out Type classType);
        return classType;
    }
}
