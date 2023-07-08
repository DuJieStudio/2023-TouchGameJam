using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : SingletonMono<EventManager>
{
    protected override void onInit()
    {
        base.onInit();
        DontDestroyOnLoad(gameObject);
    }
    
    readonly Dictionary<Type, List<Delegate>> eventTable =  new();

    public void DispatchEvent<T>(T e) where T : EventArgs
    {
        Type eventType = typeof(T);
        if (eventTable.TryGetValue(eventType, out List<Delegate> listeners))
        {
            foreach (Delegate listener in listeners)
            {
                if (listener is EventHandler<T> handler)
                {
                    handler(this, e);
                }
            }
        }
    }

    public void AddListener<T>(EventHandler<T> listener) where T : EventArgs
    {
        Type eventType = typeof(T);
        if (!eventTable.TryGetValue(eventType, out List<Delegate> listeners))
        {
            listeners = new List<Delegate>();
            eventTable.Add(eventType, listeners);
        }

        listeners.Add(listener);
    }

    public void RemoveListener<T>(EventHandler<T> listener) where T : EventArgs
    {
        Type eventType = typeof(T);
        if (eventTable.TryGetValue(eventType, out List<Delegate> listeners))
        {
            listeners.Remove(listener);
        }
    }
}