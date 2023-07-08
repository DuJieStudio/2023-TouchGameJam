using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T : Singleton<T>, new()
{
    private static T _instance;
    private static readonly object _lock = new object();

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new T();
                    _instance.onInit();
                }
            }
            return _instance;
        }
    }

    protected virtual void onInit() {}
}

public class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T> 
{
    private static T _instance;
    private static readonly object _lock = new object();

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject(typeof(T).Name);
                        _instance = go.AddComponent<T>();
                    }
                    _instance.onInit();
                }
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            _instance.onInit();
        }
    }

    protected virtual void onInit(){}
}