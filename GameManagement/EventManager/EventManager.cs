using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{

    private Dictionary<string, UnityEvent> GlobalEvents;
    private Dictionary<GameObject, Dictionary<string, UnityEvent>> StatusEvents;

    private static EventManager eventManager;

    public static EventManager Instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (GlobalEvents == null)
        {
            GlobalEvents = new Dictionary<string, UnityEvent>();
            StatusEvents = new Dictionary<GameObject, Dictionary<string, UnityEvent>>();
        }
    }

    public static void StartListening(GameObject gameObject, string eventName, UnityAction listener)
    {
        Dictionary<string, UnityEvent> dictionary;
        UnityEvent thisEvent;
        if(Instance.StatusEvents.TryGetValue(gameObject, out dictionary))
        {
            if(dictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                dictionary.Add(eventName, thisEvent);
            }
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            dictionary = new Dictionary<string, UnityEvent>();
            dictionary[eventName] = thisEvent;
            Instance.StatusEvents[gameObject] = dictionary;
        }
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.GlobalEvents.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.GlobalEvents.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(GameObject gameObject, string eventName, UnityAction listener)
    {
        if (eventManager == null) return;
        UnityEvent thisEvent;
        Dictionary<string, UnityEvent> dictionary;
        if(Instance.StatusEvents.TryGetValue(gameObject, out dictionary))
        {
            if(dictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (eventManager == null) return;
        UnityEvent thisEvent = null;
        if (Instance.GlobalEvents.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.GlobalEvents.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

    public static void TriggerEvent(GameObject gameObject, string eventName)
    {
        Dictionary<string, UnityEvent> dictionary;
        UnityEvent thisEvent;
        if(Instance.StatusEvents.TryGetValue(gameObject, out dictionary))
        {
            if(dictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}
