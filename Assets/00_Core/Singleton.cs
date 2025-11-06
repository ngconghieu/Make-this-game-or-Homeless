using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake() => LoadInstance();

    private void LoadInstance()
    {
        if (Instance != null)
        {
            Debug.LogError($"Instance of {typeof(T).Name} already exists. Destroying duplicate.");
            Destroy(gameObject);
            return;

        }
        DontDestroyOnLoad(gameObject);
        Instance = this as T;
    }
}