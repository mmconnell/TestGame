using UnityEngine;
using System.Collections.Generic;
using System;

public class InformationManager : MonoBehaviour
{
    public bool isLogging = false;
    private static bool endGame = false;

    private Dictionary<GameObject, Dictionary<Type, MonoBehaviour>> singletonRegisteredComponents;

    private static List<string> TemporaryTags = new List<string>
    {
        "spell",
    };

    private static InformationManager informationManager;

    private static InformationManager Instance
    {
        get
        {
            if (!informationManager)
            {
                informationManager = FindObjectOfType(typeof(InformationManager)) as InformationManager;

                if (!informationManager)
                {
                    Debug.LogError("There needs to be one active InformationManager script on a GameObject in your scene.");
                }
                else
                {
                    informationManager.Init();
                }
            }

            return informationManager;
        }
    }

    void Init()
    {
        if (singletonRegisteredComponents == null)
        {
            singletonRegisteredComponents = new Dictionary<GameObject, Dictionary<Type, MonoBehaviour>>();
        }
    }

    public static void RegisterComponent(GameObject go, Type type, MonoBehaviour monoBehaviour)
    {
        if (go == null || endGame)
        {
            return;
        }
        Dictionary<Type, MonoBehaviour> monoBehaviours;
        if (Instance.singletonRegisteredComponents.TryGetValue(go, out monoBehaviours))
        {
            if (monoBehaviours != null)
            {
                if (monoBehaviours.ContainsKey(type))
                {
                    monoBehaviours[type] = monoBehaviour;
                }
                else
                {
                    monoBehaviours.Add(type, monoBehaviour);
                }
            }
            else
            {
                monoBehaviours = new Dictionary<Type, MonoBehaviour>
                {
                    { type, monoBehaviour }
                };
                Instance.singletonRegisteredComponents.Add(go, monoBehaviours);
            }
        }
        else
        {
            monoBehaviours = new Dictionary<Type, MonoBehaviour>
            {
                { type, monoBehaviour }
            };
            Instance.singletonRegisteredComponents.Add(go, monoBehaviours);
        }
    }

    public static void UnRegisterComponent(GameObject go, Type type)
    {
        if (go == null || endGame)
        {
            return;
        }
        Dictionary<Type, MonoBehaviour> monoBehaviours;
        if (Instance.singletonRegisteredComponents.TryGetValue(go, out monoBehaviours))
        {
            if (monoBehaviours != null)
            {
                if (monoBehaviours.ContainsKey(type))
                {
                    monoBehaviours.Remove(type);
                    if (monoBehaviours.Keys.Count == 0)
                    {
                        Instance.singletonRegisteredComponents.Remove(go);
                    }
                }
            }
        }
    }

    public static MonoBehaviour GetRegisteredComponent(GameObject go, Type type)
    {
        if (go == null || endGame)
        {
            return null;
        }
        Dictionary<Type, MonoBehaviour> monoBehaviours;
        if (Instance.singletonRegisteredComponents.TryGetValue(go, out monoBehaviours))
        {
            if (monoBehaviours == null || endGame)
            {
                return null;
            }
            MonoBehaviour monoBehaviour;
            if (monoBehaviours.TryGetValue(type, out monoBehaviour))
            {
                if (monoBehaviour.isActiveAndEnabled)
                {
                    return monoBehaviour;
                }
                return null;
            }
        }
        return null;
    }

    public void OnDestroy()
    {
        endGame = true;
    }

    public static bool IsTemporaryTag(string tag)
    {
        return TemporaryTags.Contains(tag);
    }

    public static int RandomPercent()
    {
        return UnityEngine.Random.Range(0, 101);
    }

    public static void Log(string info)
    {
        if (Instance.isLogging)
        {
            Debug.Log(info);
        }
    }
}
