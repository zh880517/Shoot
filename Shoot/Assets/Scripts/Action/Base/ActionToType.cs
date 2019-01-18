using System;
using System.Collections.Generic;

public static class ActionToType
{
    private static readonly Dictionary<EntityActionType, Type> typeMap = new Dictionary<EntityActionType, Type>()
    {

    };

    public static Type TypeToClassType(EntityActionType type)
    {
        typeMap.TryGetValue(type, out Type classType);
        return classType;
    }
}
