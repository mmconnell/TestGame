using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InformationManager : MonoBehaviour
{
    private Dictionary<GameObject, I_EntityManager> Managers;
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
        if (Managers == null)
        {
            Managers = new Dictionary<GameObject, I_EntityManager>();
        }
    }

    public static I_EntityManager GetManager(GameObject go)
    {
        I_EntityManager manager;
        if(Instance.Managers.TryGetValue(go, out manager))
        {
            return manager;
        }
        I_EntityManager entityManager;
        entityManager = go.GetComponent<CharacterManager>();
        if (entityManager != null)
        {
            Instance.Managers.Add(go, entityManager);
            return entityManager;
        }
        Instance.Managers.Add(go, null);
        return entityManager;
    } 

    public static bool IsTemporaryTag(string tag)
    {
        return TemporaryTags.Contains(tag);
    }
}
