using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static Component CheckForNull(Component component, Type type, GameObject gameObject)
    {
        if (component == null)
        {
            Debug.LogWarning("The target of the" + type.Name + " Component on the " + gameObject.name + " is empty" );
        }
        return component;
    }
}
