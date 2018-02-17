using UnityEngine;
using System;
using System.Collections.Generic;

public class AuraColliderChecker : MonoBehaviour
{
    public Type AuraEffect;
    CircleCollider2D circleCollider;
    private Dictionary<GameObject, Component> attached;

    void Start()
    {
        attached = new Dictionary<GameObject, Component>();
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, circleCollider.radius);
        foreach(Collider2D collider in colliders)
        {
            if (collider.transform != gameObject.transform.parent)
            {
                if (collider.gameObject.GetComponent<CharacterManager>() != null)
                {
                    Component comp = collider.gameObject.AddComponent(AuraEffect);
                    attached.Add(collider.gameObject, comp);
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject go = collider.gameObject;
        if (!attached.ContainsKey(go))
        {
            CharacterManager cm = collider.gameObject.GetComponent<CharacterManager>();
            if (cm != null)
            {
                Component comp = go.AddComponent(AuraEffect);
                attached.Add(go, comp);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        Component comp = attached[go];
        if (comp != null)
        {
            Destroy(comp);
            attached.Remove(go);
        }
    }

    void OnDisable()
    {
        foreach(Component comp in attached.Values)
        {
            Destroy(comp);
        }
    }
}
