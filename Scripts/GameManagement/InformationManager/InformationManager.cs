using UnityEngine;
using System.Collections.Generic;
using System;
using Manager;

public class InformationManager : MonoBehaviour
{
    public bool isLogging = false;
    public static int maxTools = 20;
    private static bool endGame = false;

    private Dictionary<GameObject, ToolManager> toolManagers;

    private static List<string> TemporaryTags = new List<string>
    {
        "spell",
    };

    private static InformationManager informationManager;

    public static InformationManager Instance
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
        if (toolManagers == null)
        {
            toolManagers = new Dictionary<GameObject, ToolManager>();
        }
    }

    public static void RegisterToolManager(GameObject go, ToolManager toolManager)
    {
        if (go == null || endGame)
        {
            return;
        }
        if (Instance.toolManagers.ContainsKey(go))
        {
            Instance.toolManagers[go] = toolManager;
        }
        else
        {
            Instance.toolManagers.Add(go, toolManager);
        }
    }

    public static void UnRegisterToolManager(GameObject go)
    {
        if (go == null || endGame)
        {
            return;
        }
        if (Instance.toolManagers.ContainsKey(go))
        {
            Instance.toolManagers.Remove(go);
        }
    }

    public static ToolManager GetRegisteredToolManager(GameObject go)
    {
        if (go == null || endGame)
        {
            return null;
        }
        ToolManager tm;
        if (Instance.toolManagers.TryGetValue(go, out tm))
        {
            return tm;
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

    public static int RandomNumber(int number)
    {
        return UnityEngine.Random.Range(0, number);
    }

    public static float RandomFloat(float number)
    {
        return UnityEngine.Random.Range(0f, number);
    }

    public static void Log(string info)
    {
        Debug.Log(info);
    }

    public static bool IsLogging()
    {
        return Instance.isLogging;
    }

    public static int GetMaxTools()
    {
        return maxTools;
    }
}
