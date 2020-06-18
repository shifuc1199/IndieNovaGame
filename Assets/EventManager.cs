using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EventTypeArg
{
    AddBagModule,
    EquipModule
}

public class EventManager
{
    public Dictionary<EventTypeArg, Delegate> eventDict = new Dictionary<EventTypeArg, Delegate>();

    public void AddListener(EventTypeArg eventType, Action callBack)
    {
        if (eventDict.ContainsKey(eventType))
        {
            eventDict[eventType] =  (Action)eventDict[eventType]+callBack;
        }
        else
        {
            eventDict.Add(eventType, callBack);
        }
    }
    public void AddListener<T>(EventTypeArg eventType, Action<T> callBack)
    {
        if (eventDict.ContainsKey(eventType))
        {
            eventDict[eventType] =  (Action<T>)eventDict[eventType]+callBack;
        }
        else
        {
            eventDict.Add(eventType, callBack);
        }
    }  
    public void BroadCast<T>(EventTypeArg eventType,T arg)
    {
        if (!eventDict.ContainsKey(eventType))
        {
            return;
        }
        (eventDict[eventType] as Action<T>)?.Invoke(arg);
    }
    public void BroadCast(EventTypeArg eventType)
    {
        if (!eventDict.ContainsKey(eventType))
        {
            return;
        }
        (eventDict[eventType] as Action)?.Invoke();
    }  
    public void RemoveListener<T>(EventTypeArg eventType, Action<T> callBack)
    {
        if (!eventDict.ContainsKey(eventType))
        {
            return;
        }
        else
        {
            eventDict[eventType] =  (Action<T>)eventDict[eventType]-callBack;
            if (eventDict[eventType] == null)
            {
                eventDict.Remove(eventType);
            }
        }
    }
    public void RemoveListener(EventTypeArg eventType, Action callBack)
    {
        if (!eventDict.ContainsKey(eventType))
        {
           return;
        }
        else
        {
            eventDict[eventType] =  (Action)eventDict[eventType]-callBack;
            if (eventDict[eventType] == null)
            {
                eventDict.Remove(eventType);
            }
        }
    }
}
