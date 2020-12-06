using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class EventSystem
{
    private static Dictionary<Type, List<IListenerBase>> subscribersList;

    static EventSystem()
    {
        subscribersList = new Dictionary<Type, List<IListenerBase>>();
    }

    public static void AddListener<EventType>(IEventListener<EventType> listener) where EventType : struct
    {
        Type eventType = typeof(EventType); //Получаем тип евентов
        if (!subscribersList.ContainsKey(eventType)) //Проверяем присутсвует ли в словаре список подписчиков для этого типа
        {
            subscribersList[eventType] = new List<IListenerBase>();
        }
        subscribersList[eventType].Add(listener);
    }

    public static void RemoveListener<EventType>(IEventListener<EventType> listener) where EventType : struct
    {
        Type eventType = typeof(EventType);
        if (subscribersList.ContainsKey(eventType))
        {
            List<IListenerBase> list = subscribersList[eventType];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == listener)
                {
                    list.Remove(list[i]);
                    if (list.Count == 0)
                    {
                        subscribersList.Remove(eventType);
                    }
                }
            }
        }
        else
        {
            return;
        }
    }

    public static void OnEventTrigger<EventType>(EventType triggeredEvent) where EventType : struct
    {
        Type eventType = typeof(EventType);
        if (subscribersList.ContainsKey(eventType))
        {
            List<IListenerBase> list = subscribersList[eventType];
            for (int i = 0; i < list.Count; i++)
            {
                (list[i] as IEventListener<EventType>).OnEventTrigger(triggeredEvent);
            }
        }
    }
}
