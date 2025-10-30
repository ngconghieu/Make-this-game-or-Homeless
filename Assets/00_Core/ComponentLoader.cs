using System;
using UnityEngine;

public static class ComponentLoader
{
    public static void LoadComponent<T>(ref T component, Component obj) where T : Component
    {
        if (component != null) return;
        component = obj.GetComponent<T>();
        DebugLog(typeof(T).Name, obj);
    }

    public static void LoadComponentInParent<T>(ref T component, Component obj) where T : Component
    {
        if (component != null) return;
        component = obj.GetComponentInParent<T>();
        DebugLog(typeof(T).Name, obj);
    }

    public static void LoadComponentInChildren<T>(ref T component, Component obj) where T : Component
    {
        if (component != null) return;
        component = obj.GetComponentInChildren<T>();
        DebugLog(typeof(T).Name, obj);
    }

    private static void DebugLog(string name, Component obj)
    {
        Debug.Log(name, obj);
    }
}
